using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KHWR.kNN.Enum;

namespace KHWR.kNN.Common
{
  public class TraceGroup
  {
    public TraceGroup()
    {
      Traces = new List<Trace>();
      XScaleFactor = 1.0f;
      YScaleFactor = 1.0f;
    }

    public IList<Trace> Traces { get; set; }

    public float XScaleFactor { get; set; }

    public float YScaleFactor { get; set; }

    public CaptureDevice CaptureDevice { get; set; }

    public BoundingBox GetBoundingBox()
    {
      var box = new BoundingBox();

      box.XMin = box.YMin = (float)Math.Pow(10, 37);
      box.XMax = box.YMax = -(float) Math.Pow(10, 37);
      int numPoints = 0;
      foreach(var trace in Traces)
      {
        var xVec = trace.ChannelX;
        var yVec = trace.ChannelY;

        numPoints = xVec.Count;

        for(var i = 0;i<numPoints; i++)
        {
          float x, y;
          x = xVec[i];
          y = yVec[i];

          if (x < box.XMin) box.XMin = x;
          if (x > box.XMax) box.XMax = x;
          if (y < box.YMin) box.YMin = y;
          if (y > box.YMax) box.YMax = y;
        }
      }

      return box;
    }

    public void AffineTransform(float xScaleFactor, float yScaleFactor, float translateToX, float translateToY, TraceGroupCornerEnum referenceCorner)
    {
      var outTraceGroup = new TraceGroup();
      float xReference = 0f, yReference = 0f;
      float x, y;

      if (xScaleFactor <= 0) //invalid
      {
      }

      if (yScaleFactor <= 0)
      {
        //invalid
      }

      var box = GetBoundingBox();

      switch (referenceCorner)
      {
        case TraceGroupCornerEnum.XMin_YMin:
          xReference = box.XMin;
          yReference = box.YMin;
          break;
        case TraceGroupCornerEnum.XMin_YMax:
          xReference = box.XMin;
          yReference = box.YMax;
          break;
        case TraceGroupCornerEnum.XMax_YMin:
          xReference = box.XMax;
          yReference = box.YMin;
          break;
        case TraceGroupCornerEnum.XMax_YMax:
          xReference = box.XMax;
          yReference = box.YMax;
          break;
        default:
          break;
      }

      foreach(var trace in Traces)
      {
        var xVec = trace.ChannelX;
        var yVec = trace.ChannelY;

        var scaleTrace = new Trace();
        foreach (var point in trace.Points)
        {
          //the additive term is to translate back the scaled tracegroup
          //so that the corner asked for is preserved at the destination
          //(translateToX,translateToY)
          x = (point.X*xScaleFactor)/XScaleFactor + (translateToX - (xReference*(xScaleFactor/XScaleFactor)));

          //the additive term is to translate back the scaled tracegroup
          //so that the corner asked for is preserved at the destination
          //(translateToX,translateToY)
          y = (point.Y*yScaleFactor)/YScaleFactor + (translateToY - (yReference*(yScaleFactor/YScaleFactor)));

          scaleTrace.Points.Add(new PenPoint{X=x, Y=y});
        }
        outTraceGroup.Traces.Add(scaleTrace);
      }

      Traces = outTraceGroup.Traces;

      XScaleFactor = xScaleFactor;
      YScaleFactor = yScaleFactor;

      //return outTraceGroup;
    }
  }
}
