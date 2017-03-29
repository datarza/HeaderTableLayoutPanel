using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CBComponents;

namespace Examples
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
      Type _type = typeof(HeaderTableLayoutPanel.HighlightCaptionStyle);
      foreach (var _style in Enum.GetValues(_type))
        this.toolStrip1.Items.Add(new ToolStripButton() {
          Text = Enum.GetName(_type, _style),
          Tag = _style,
          DisplayStyle = ToolStripItemDisplayStyle.Text });
      this.toolStrip1.Items[1].PerformClick();
      this.Shown += delegate { this.textBox1.Focus(); };
      this.FormClosed += delegate { Application.Exit(); };
    }

    private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      if (e.ClickedItem.Tag is HeaderTableLayoutPanel.HighlightCaptionStyle)
      {
        var _style = (HeaderTableLayoutPanel.HighlightCaptionStyle)e.ClickedItem.Tag;
        foreach (Control _panel in this.flowLayoutPanel1.Controls)
          if (_panel is HeaderTableLayoutPanel)
            ((HeaderTableLayoutPanel)_panel).CaptionStyle = _style;
      }
      foreach (ToolStripItem _button in this.toolStrip1.Items)
        if (_button is ToolStripButton)
          ((ToolStripButton)_button).Checked = false;
      ((ToolStripButton)e.ClickedItem).Checked = true;
    }
  }
}
