using System;
using System.Text;
using System.Windows.Forms;
using KHWR.kNN.Common;
using KHWR.kNN.Helper;
using KHWR.kNN.Reco;
using Microsoft.Ink;
using Cursors = System.Windows.Forms.Cursors;

namespace KHWR.kNN.View
{
  public partial class RecognizerForm : Form
  {
    private NNRecognizer _recognizer;

    private InkOverlay _drawingInk;

    public RecognizerForm()
    {
      InitializeComponent();

      //Initialize service
      _recognizer = new NNRecognizer();

      _drawingInk = new InkOverlay(pnlDrawing.Handle)
      {
        AttachedControl = pnlDrawing,
        Enabled = true,
        DynamicRendering = true
      };

      _drawingInk.Stroke += new InkCollectorStrokeEventHandler(drawingInk_Stroke);
    }

    #region Overlay Ink

    private void drawingInk_Stroke(object sender, EventArgs e)
    {
      if(chkAutoRecognize.Checked) btnRecognizer_Click(null, null);
    }

    #endregion

    private void btnTrain_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      
      _recognizer.Train();
      MessageBox.Show("Train is done!");

      Cursor = Cursors.Default;
    }

    private void btnRecognizer_Click(object sender, EventArgs e)
    {
      var traceGroup = _drawingInk.Ink.ToTraceGroup();
      var captureDevice = new CaptureDevice { XDpi = 300, YDpi = 300, SamplingRate = 100, Latency = 0f };
      traceGroup.CaptureDevice = captureDevice;
      var results = _recognizer.Recognize(traceGroup);

      var buffer = new StringBuilder();
      foreach (var r in results)
      {
        buffer.AppendLine(r.ToString());
      }
      lblResult.Text = buffer.ToString();

      lblGuessChar.Text = results[0].ShapeCharacter;
    }

    private void btnDrawingClear_Click(object sender, EventArgs e)
    {
      _drawingInk.Ink.DeleteStrokes();
      _drawingInk.AttachedControl.Invalidate();
    }
  }
}
