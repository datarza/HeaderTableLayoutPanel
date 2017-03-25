using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
  public partial class UnitTest
  {
    [TestMethod]
    public void ForeColor()
    {
      using (var _to = new TestObjects(true))
      {
        // setting default line width = 2
        _to.SuspendLayout();
        _to.Panel.CaptionStyle = CBComponents.HeaderTableLayoutPanel.HighlightCaptionStyle.ForeColor;
        _to.Panel.CaptionText = "Test";
        _to.Panel.CaptionLineWidth = 2;
        _to.PerformLayout();
        var _height1 = _to.Panel.Height;

        // increasing line width by 8
        _to.SuspendLayout();
        _to.Panel.CaptionLineWidth = 10;
        _to.PerformLayout();
        var _height2 = _to.Panel.Height;
        Assert.AreEqual(_height1, _height2 - 8);

        // decreasing line width by 10
        _to.SuspendLayout();
        _to.Panel.CaptionLineWidth = 0;
        _to.PerformLayout();
        var _height3 = _to.Panel.Height;
        Assert.AreEqual(_height1, _height3 + 2);

      }
    }
  }
}
