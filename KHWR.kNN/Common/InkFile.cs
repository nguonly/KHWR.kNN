using System;
using System.IO;

namespace KHWR.kNN.Common
{
  public class InkFile
  {
    public TraceGroup ReadFromInkFile(string path)
    {
      var outTraceGroup = new TraceGroup();
      var input = new FileStream(path, FileMode.Open, FileAccess.Read);
      var fileReader = new StreamReader(input);
      var strLine = "";
      char[] splitter = { ' ' };

      var captureDevice = new CaptureDevice { SamplingRate = 100, Latency = 0f };
      while(!fileReader.EndOfStream)
      {
        strLine = fileReader.ReadLine();
        if (strLine == null) continue;
        
        //Read header info
        if (strLine.Contains(".X_POINTS_PER_INCH"))
        {
          var strToken = strLine.Split(splitter, StringSplitOptions.None);
          captureDevice.XDpi = Convert.ToInt32(strToken[1]);
        }

        if (strLine.Contains(".Y_POINTS_PER_INCH"))
        {
          var strToken = strLine.Split(splitter, StringSplitOptions.None);
          captureDevice.YDpi = Convert.ToInt32(strToken[1]);
        }

        if (strLine.Contains(".POINTS_PER_SECOND"))
        {
          var strToken = strLine.Split(splitter, StringSplitOptions.None);
          //use later
        }

        if (!strLine.Trim().Equals(".PEN_DOWN")) continue;
        
        var strCoord = "";

        var trace = new Trace();
        while(!(strCoord = fileReader.ReadLine()?? "").Trim().Equals(".PEN_UP") && !fileReader.EndOfStream)
        {
          
          var strToken = strCoord.Split(splitter, StringSplitOptions.None);

          var x = Convert.ToInt32(strToken[0]);
          var y = Convert.ToInt32(strToken[1]);

          trace.Points.Add(new PenPoint{X=x, Y=y});
        }
        outTraceGroup.Traces.Add(trace);
      }

      fileReader.Close();
      input.Close();

      outTraceGroup.CaptureDevice = captureDevice;

      return outTraceGroup;
    }
  }
}
