using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KHWR.kNN.Common
{
  public class Trace
  {
    public Trace()
    {
      
      Points = new List<PenPoint>();
    }

    public IList<float> ChannelX { get { return Points.Select(p => p.X).ToList(); } }
    public IList<float> ChannelY { get { return Points.Select(p => p.Y).ToList(); } }

    public IList<PenPoint> Points { get; set; }

    public float GetSumX()
    {
      return ChannelX.Sum();
    }

    public float GetSumY()
    {
      return ChannelY.Sum();
    }
  }
}
