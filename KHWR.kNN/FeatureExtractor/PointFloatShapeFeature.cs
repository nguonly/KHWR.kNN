using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KHWR.kNN.FeatureExtractor
{
  public class PointFloatShapeFeature
  {
    public float X { get; set; }

    public float Y { get; set; }

    public float SinTheta { get; set; }

    public float CosTheta { get; set; }

    public bool IsPenUp { get; set; }

    public string DataDelimiter { get; set; }

    public float GetDistance(PointFloatShapeFeature otherFeature)
    {
      var xDiff = X - otherFeature.X;
      var yDiff = Y - otherFeature.Y;

      var sinThetaDiff = SinTheta - otherFeature.SinTheta;
      var cosThetaDiff = CosTheta - otherFeature.CosTheta;

      var distance = xDiff*xDiff + yDiff*yDiff + sinThetaDiff*sinThetaDiff + cosThetaDiff*cosThetaDiff;

      return distance;
    }
  }
}
