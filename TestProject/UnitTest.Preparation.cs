using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
  [TestClass]
  public partial class UnitTest
  {
    /// <summary>
    /// Creating form and panel for testing
    /// </summary>
    /// <param name="form"></param>
    /// <param name="panel"></param>
    private void CreateTestingControl(out System.Windows.Forms.Form form, out CBComponents.HeaderTableLayoutPanel panel)
    {
      form = new System.Windows.Forms.Form();
      form.SuspendLayout();
      form.SetDesktopBounds(0, 0, 640, 480);

      panel = new CBComponents.HeaderTableLayoutPanel();
      form.Controls.Add(panel);
      panel.SetBounds(0, 0, 320, 240);

      form.ResumeLayout(false);
      form.PerformLayout();
    }

    /// <summary>
    /// Disposing form and panel after testing
    /// </summary>
    /// <param name="form"></param>
    /// <param name="panel"></param>
    private void DisposeTestingControl(ref System.Windows.Forms.Form form, ref CBComponents.HeaderTableLayoutPanel panel)
    {
      form.Dispose();
      panel = null;
      form = null;
    }

    [TestMethod]
    public void TestProjectPreparation()
    {
      // Creating panel
      System.Windows.Forms.Form form;
      CBComponents.HeaderTableLayoutPanel panel;
      this.CreateTestingControl(out form, out panel);

      // running tests
      Assert.AreEqual(panel.Parent, form);
      Assert.AreEqual(form.Location, new System.Drawing.Point(0, 0));
      Assert.AreEqual(form.Width, 640);
      Assert.AreEqual(form.Height, 480);
      Assert.AreEqual(panel.Location, new System.Drawing.Point(0, 0));
      Assert.AreEqual(panel.Width, 320);
      Assert.AreEqual(panel.Height, 240);

      // Disposing panel
      this.DisposeTestingControl(ref form, ref panel);
    }
  }
}
