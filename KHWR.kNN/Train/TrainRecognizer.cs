using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using KHWR.kNN.Common;
using KHWR.kNN.FeatureExtractor;
using KHWR.kNN.PreProc;

namespace KHWR.kNN.Train
{
  public class TrainRecognizer
  {
    private PointFloatShapeFeatureExtractor _featureExtractor;
    private InkFile _inkFile;
    private PreProcessing _preProc;

    public TrainRecognizer()
    {
      _featureExtractor = new PointFloatShapeFeatureExtractor();
      _inkFile = new InkFile();
      _preProc = new PreProcessing();
    }

    public IList<TrainFeature> Train()
    {
      var path = @"..\..\data\trainlist.txt";
      var input = new FileStream(path, FileMode.Open, FileAccess.Read);
      var fileReader = new StreamReader(input);
      char[] splitter = { ' ' };
      var strLine = "";

      var trainList = new List<TrainFeature>();
      while (!fileReader.EndOfStream)
      {
        strLine = fileReader.ReadLine();
        if (strLine == null) break;

        var strToken = strLine.Split(splitter, StringSplitOptions.None);
        var inkPath = strToken[0];
        var classId = Convert.ToInt32(strToken[1]);
        var traceGroup = _inkFile.ReadFromInkFile(inkPath);
        var prepTraceGroup = _preProc.PreProcess(traceGroup);
        var feature = _featureExtractor.ExtractFeature(prepTraceGroup);

        trainList.Add(new TrainFeature{ClassId = classId, ShapeFeatures = feature});
      }

      return trainList;
    }
  }
}
