using System.Linq;
using KHWR.kNN.Common;
using Microsoft.Ink;

namespace KHWR.kNN.Helper
{
  public static class TraceHelper
  {
    public static TraceGroup ToTraceGroup(this Ink ink)
    {
      var traceGroup = new TraceGroup();
      foreach(var stroke in ink.Strokes)
      {
        var trace = new Trace();
        foreach(var point in stroke.GetPoints())
        {
          var penPoint = new PenPoint {X = point.X, Y = point.Y};
          trace.Points.Add(penPoint);
        }
        traceGroup.Traces.Add(trace);
      }

      return traceGroup;
    }

    public static Ink ToInk(this TraceGroup traceGroup)
    {
      var ink = new Ink();

      foreach (var trace in traceGroup.Traces)
      {
        //var points = new Point[trace.Points.Count];
        //foreach (var point in trace.Points)
        //{
          
        //}
        var points = trace.Points.ToList().ConvertAll(c => c.ToPoint());
        var stroke = ink.CreateStroke(points.ToArray());
        ink.Strokes.Add(stroke);
      }
      return ink;
    }
  }
}
