using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KHWR.kNN.Enum;

namespace KHWR.kNN.Common
{
  public class Channel
  {
    public string Name { get; set; }
    public ChannelTypeEnum Type { get; set; }
    public bool IsRegularChannel { get; set; }
  }
}
