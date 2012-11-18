using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KHWR.kNN.Common
{
  public class CaptureDevice
  {
    public int SamplingRate { get; set; }
    public int XDpi { get; set; }
    public int YDpi { get; set; }
    public float Latency { get; set; }  //interval between the time of actual input to that of its registration

    public bool IsUniformSamplingRate { get; set; }
  }
}
