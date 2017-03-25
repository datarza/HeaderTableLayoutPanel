using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
  public partial class UnitTest
  {
    [TestMethod]
    public void ForeColor()
    {
      // Creating panel
      System.Windows.Forms.Form form;
      CBComponents.HeaderTableLayoutPanel panel;
      this.CreateTestingControl(out form, out panel);

      // running tests
      // TODO: write tests

      // Disposing panel
      this.DisposeTestingControl(ref form, ref panel);
    }
  }
}
