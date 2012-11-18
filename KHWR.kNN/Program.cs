using System;
using System.Windows.Forms;
using KHWR.kNN.View;

namespace KHWR.kNN
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new PreProcessForm());
    }
  }
}
