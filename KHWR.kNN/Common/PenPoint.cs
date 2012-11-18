using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace KHWR.kNN.Common
{
  public class PenPoint
  {
    public float X { get; set; }
    public float Y { get; set; }

    public Point ToPoint()
    {
      return new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
    }
  }
}
