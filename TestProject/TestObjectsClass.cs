using System;

namespace TestProject
{
  /// <summary>
  /// Form and Panel for testing
  /// </summary>
  internal class TestObjects : IDisposable
  {
    public System.Windows.Forms.Form Form { get; private set; }
    public CBComponents.HeaderTableLayoutPanel Panel { get; private set; }

    public TestObjects(bool PrepareEditControls = false)
    {
      this.Form = new System.Windows.Forms.Form();
      this.Form.SuspendLayout();
      this.Form.SetDesktopBounds(0, 0, 640, 480);

      this.Panel = new CBComponents.HeaderTableLayoutPanel();
      this.Form.Controls.Add(this.Panel);
      this.Panel.SetBounds(0, 0, 320, 240);

      if (PrepareEditControls) this.PrepareEditControls();

      this.Form.ResumeLayout(false);
      this.Form.PerformLayout();
    }

    private void PrepareEditControls()
    {
      if (this.Form == null || this.Panel == null || this.Panel.Parent != this.Form) return;
      
      this.Panel.AutoSize = true;
      this.Panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Panel.CaptionText = "Personal";
      this.Panel.ColumnCount = 2;
      this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.Panel.RowCount = 3;
      this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
      
      this.Panel.Controls.Add(new System.Windows.Forms.Label()
      {
        Text = "Label1:",
        TextAlign = System.Drawing.ContentAlignment.MiddleRight,
        Anchor = System.Windows.Forms.AnchorStyles.Right,
        AutoSize = true,
      }, 0, 0);
      this.Panel.Controls.Add(new System.Windows.Forms.Label()
      {
        Text = "Label2:",
        TextAlign = System.Drawing.ContentAlignment.MiddleRight,
        Anchor = System.Windows.Forms.AnchorStyles.Right,
        AutoSize = true,
      }, 0, 1);
      this.Panel.Controls.Add(new System.Windows.Forms.Label()
      {
        Text = "Label3:",
        TextAlign = System.Drawing.ContentAlignment.MiddleRight,
        Anchor = System.Windows.Forms.AnchorStyles.Right,
        AutoSize = true,
      }, 0, 2);
      
      this.Panel.Controls.Add(new System.Windows.Forms.TextBox()
      {
        Text = "TextBox",
        Anchor = System.Windows.Forms.AnchorStyles.Left,
        AutoSize = false,
      }, 1, 0);
      this.Panel.Controls.Add(new System.Windows.Forms.ComboBox()
      {
        Text = "DropDown",
        DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown,
        Anchor = System.Windows.Forms.AnchorStyles.Left,
        AutoSize = false,
      }, 1, 1);
      this.Panel.Controls.Add(new System.Windows.Forms.ComboBox()
      {
        Text = "DropDownList",
        DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList,
        Anchor = System.Windows.Forms.AnchorStyles.Left,
        AutoSize = false,
      }, 2, 2);
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
