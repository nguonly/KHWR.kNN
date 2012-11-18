using System;
using System.IO;
using KHWR.kNN.Common;
using KHWR.kNN.Reco;

namespace KHWR.kNN.Test
{
  public class TestRecognizer
  {
    private InkFile _inkFile;
    private NNRecognizer _recognizer;

    public TestRecognizer()
    {
      _inkFile = new InkFile();
      _recognizer = new NNRecognizer();

      //Train recognizer
      _recognizer.Train();
    }

    /// <summary>
    /// Test the recognizer with testlist.txt
    /// </summary>
    /// <returns>percentage of accuracy</returns>
    public decimal Test()
    {
      var path = @"..\..\data\testlist.txt";
      var input = new FileStream(path, FileMode.Open, FileAccess.Read);
      var fileReader = new StreamReader(input);
      char[] splitter = { ' ' };
      var strLine = "";
      var correctNo = 0;
      var totalTest = 0;

      while (!fileReader.EndOfStream)
      {
        strLine = fileReader.ReadLine();
        if (strLine == null) break;

        var strToken = strLine.Split(splitter, StringSplitOptions.None);
        var inkPath = strToken[0];
        var classId = Convert.ToInt32(strToken[1]);
        var traceGroup = _inkFile.ReadFromInkFile(inkPath);

        var result = _recognizer.Recognize(traceGroup);

        totalTest++;
        if (result[0].ShapeId == classId) correctNo++;

      }

      //Caculate the accuary
      return (decimal)correctNo*100/totalTest;
    }
  }
}
