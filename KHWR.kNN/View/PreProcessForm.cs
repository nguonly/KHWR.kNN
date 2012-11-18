using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KHWR.kNN.Common;
using KHWR.kNN.FeatureExtractor;
using KHWR.kNN.Helper;
using KHWR.kNN.PreProc;
using KHWR.kNN.Reco;
using KHWR.kNN.Test;
using Microsoft.Ink;
using Cursors = System.Windows.Forms.Cursors;

namespace KHWR.kNN.View
{
  public partial class PreProcessForm : Form
  {
    private NNRecognizer _recognizer;

    private InkOverlay _drawingInk;
    private InkOverlay _resultInk;

    public PreProcessForm()
    {
      InitializeComponent();

      //Initialize the service
      _recognizer = new NNRecognizer();

      _drawingInk = new InkOverlay(pnlDrawing.Handle)
                      {
                        AttachedControl = pnlDrawing,
                        Enabled = true,
                        DynamicRendering = true
                      };

      _drawingInk.Stroke += new InkCollectorStrokeEventHandler(drawingInk_Stroke);

      _resultInk = new InkOverlay(pnlResult.Handle);
      _resultInk.AttachedControl = pnlResult;
      _resultInk.Enabled = true;
      _resultInk.DynamicRendering = true;
    }

    ~PreProcessForm()
    {
      _drawingInk.Dispose();
      _resultInk.Dispose();
    }

    #region InkOverlay Events
    
    private void drawingInk_Stroke(object sender, EventArgs e)
    {
      var str = new StringBuilder();
      foreach (var stroke in _drawingInk.Ink.Strokes)
      {
        str.AppendLine(".PEN_DOWN");
        foreach (var point in stroke.GetPoints())
        {
          str.AppendLine("X=" + point.X + "   Y=" + point.Y);
        }
        str.AppendLine(".PEN_UP");
        str.AppendLine("----- Total Points = " + stroke.GetPoints().Count());
      }
      txtDrawingRaw.Text = str.ToString();
    }

    #endregion

    private void btnSmooth_Click(object sender, EventArgs e)
    {
      var traceGroup = _drawingInk.Ink.ToTraceGroup();

      //txtUnipen.Text = ReadTraceGroupInUnipenFormat(traceGroup);

      var preProc = new PreProcessing();
      var newTraceGroup = preProc.SmoothenTraceGroup(traceGroup);

      _resultInk.Enabled = false;
      _resultInk.Ink = newTraceGroup.ToInk();
      _resultInk.Enabled = true;

      txtDrawingResult.Text = ReadTraceGroupInUnipenFormat(newTraceGroup);
    }

    private void btnReSampling_Click(object sender, EventArgs e)
    {
      var preProc = new PreProcessing();

      var traceGroup = _drawingInk.Ink.ToTraceGroup();
      var resamplingTraceGroup = preProc.ResampleTraceGroup(traceGroup);

      _resultInk.Enabled = false;
      _resultInk.Ink = resamplingTraceGroup.ToInk();
      _resultInk.Enabled = true;

      txtDrawingResult.Text = ReadTraceGroupInUnipenFormat(resamplingTraceGroup);
    }

    private void btnDrawingClear_Click(object sender, EventArgs e)
    {
      _drawingInk.Ink.DeleteStrokes();
      _drawingInk.AttachedControl.Invalidate();

      _resultInk.Ink.DeleteStrokes();
      _resultInk.AttachedControl.Invalidate();

      //Clear text box
      txtDrawingRaw.Text = string.Empty;
    }

    private string ReadTraceGroupInUnipenFormat(TraceGroup traceGroup)
    {
      var str = new StringBuilder();
      foreach (var trace in traceGroup.Traces)
      {
        str.AppendLine(".PEN_DOWN");

        foreach (var point in trace.Points)
        {
          str.AppendLine("X=" + point.X + "   Y=" + point.Y);
        }
        str.AppendLine(".PEN_UP");
        str.AppendLine("----- Total Points = " + trace.Points.Count);
      }

      return str.ToString();
    }

    private void btnFeature_Click(object sender, EventArgs e)
    {
      var traceGroup = _resultInk.Ink.ToTraceGroup();
      var featureExtractor = new PointFloatShapeFeatureExtractor();

      var features = featureExtractor.ExtractFeature(traceGroup);

      var str = new StringBuilder();
      foreach (var feature in features)
      {
        str.AppendLine(string.Format("{0}  {1}  {2}  {3}  {4}", feature.X, feature.Y, feature.SinTheta, feature.CosTheta,
                                     feature.IsPenUp));

      }
      str.AppendLine("--- Total Point = " + features.Count);
      txtFeature.Text = str.ToString();
    }

    private void btnLoadRecognizerForm_Click(object sender, EventArgs e)
    {
      var recognizerForm = new RecognizerForm();

      recognizerForm.ShowDialog();
    }

    private void btnEuclidean_Click(object sender, EventArgs e)
    {
      var featureExtractor = new PointFloatShapeFeatureExtractor();
      var preProc = new PreProcessing();

      var traceGroup = _drawingInk.Ink.ToTraceGroup();
      var sampledTraceGroup = preProc.ResampleTraceGroup(chkIsNormalized.Checked?preProc.NormalizeSize(traceGroup): traceGroup);
      var features = featureExtractor.ExtractFeature(sampledTraceGroup);

      var testTraceGroup = _resultInk.Ink.ToTraceGroup();
      var sampledTestTraceGroup = preProc.ResampleTraceGroup(chkIsNormalized.Checked?preProc.NormalizeSize(testTraceGroup): testTraceGroup);
      var testFeatures = featureExtractor.ExtractFeature(sampledTestTraceGroup);
      
      var eucDistance = featureExtractor.ComputeEuclideanDistance(features, testFeatures);

      MessageBox.Show(@"Euclidean Distance = " + eucDistance);
    }

    private void btnTest_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;

      var testRecognizer = new TestRecognizer();

      var accuracy = testRecognizer.Test();

      MessageBox.Show(string.Format("Accuracy = {0:0.00}%", accuracy));

      Cursor = Cursors.Default;
    }
  }
}
