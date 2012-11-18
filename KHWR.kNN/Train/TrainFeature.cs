using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KHWR.kNN.FeatureExtractor;

namespace KHWR.kNN.Train
{
  public class TrainFeature
  {
    public IList<PointFloatShapeFeature> ShapeFeatures { get; set; }

    public int ClassId { get; set; }
  }
}
