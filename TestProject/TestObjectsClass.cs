using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject
{
  /// <summary>
  /// Form and Panel for testing
  /// </summary>
  internal class TestObjects : IDisposable
  {
    public System.Windows.Forms.Form Form { get; private set; }
    public CBComponents.HeaderTableLayoutPanel Panel { get; private set; }

    public TestObjects()
    {
      this.Form = new System.Windows.Forms.Form();
      this.Form.SuspendLayout();
      this.Form.SetDesktopBounds(0, 0, 640, 480);

      this.Panel = new CBComponents.HeaderTableLayoutPanel();
      this.Form.Controls.Add(this.Panel);
      this.Panel.SetBounds(0, 0, 320, 240);

      this.Form.ResumeLayout(false);
      this.Form.PerformLayout();
    }

    private bool disposedValue = false; 
    public void Dispose()
    {
      if (!disposedValue)
      {
        this.Form.Dispose();
        this.Form = null;
        this.Panel = null;
        disposedValue = true;
      }
    }

  }
}
