using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KHWR.kNN.Reco
{
  public class RecoResult
  {
    public static readonly string[] KhmerConsonantUnicode = {
                                                                       "ក", "ខ", "គ", "ឃ", "ង",
                                                                       "ច", "ឆ", "ជ", "ឈ", "ញ",
                                                                       "ដ", "ឋ", "ឌ", "ឍ", "ណ",
                                                                       "ត", "ថ", "ទ", "ធ", "ន",
                                                                       "ប", "ផ", "ព", "ភ", "ម",
                                                                       "យ", "រ", "ល", "វ", "ស",
                                                                       "ហ", "ឡ", "អ"
                                                                     };

    public int ShapeId { get; set; }
    public string ShapeCharacter { get { return KhmerConsonantUnicode[ShapeId]; }}
    public float ConfidenceLevel { get; set; }

    public override string ToString()
    {
      return string.Format("{0} - {1}", ShapeCharacter, ConfidenceLevel);
    }
  }
}
