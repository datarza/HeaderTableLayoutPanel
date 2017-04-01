using System;
using System.Drawing;
using System.Windows.Forms;

using CBComponents;

namespace Examples
{
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
      this.Shown += delegate { this.textBox1.Focus(); };
      this.FormClosed += delegate { Application.Exit(); };

      // buttons for changing CaptionStyle
      Type _type = typeof(HeaderTableLayoutPanel.HighlightCaptionStyle);
      foreach (var _style in Enum.GetValues(_type))
        this.toolStrip1.Items.Add(new ToolStripButton() {
          Text = Enum.GetName(_type, _style),
          Tag = _style,
          DisplayStyle = ToolStripItemDisplayStyle.Text });
      this.toolStrip1.Items[1].PerformClick();

      // strip for changing width of CaptionLineWidth
      this.toolStripComboBox1.Items.AddRange(new object[] { (byte)0, (byte)1, (byte)2, (byte)3, (byte)4, (byte)6, (byte)8, (byte)10, (byte)20 });
      this.toolStripComboBox1.SelectedIndexChanged += toolStripComboBox1_SelectedIndexChanged;
      this.toolStripComboBox1.SelectedIndex = 2;
      
      // strip for changing text of CaptionText
      this.toolStripTextBox1.TextChanged += toolStripTextBox1_TextChanged;

    }

    private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
    {
      foreach (HeaderTableLayoutPanel _panel in this.flowLayoutPanel1.Controls)
      {
        _panel.CaptionText = this.toolStripTextBox1.Text;
        _panel.PerformLayout();
      }
    }

    private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.toolStripComboBox1.SelectedItem is byte)
      {
        byte _width = (byte)this.toolStripComboBox1.SelectedItem;
        foreach (HeaderTableLayoutPanel _panel in this.flowLayoutPanel1.Controls)
        {
          _panel.CaptionLineWidth = _width;
          _panel.PerformLayout();
        }
      }
    }

    private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      if (e.ClickedItem.Tag is HeaderTableLayoutPanel.HighlightCaptionStyle)
      {
        var _style = (HeaderTableLayoutPanel.HighlightCaptionStyle)e.ClickedItem.Tag;
        foreach (HeaderTableLayoutPanel _panel in this.flowLayoutPanel1.Controls)
        {
          _panel.CaptionStyle = _style;
          _panel.PerformLayout();
        }
        foreach (ToolStripButton _button in this.toolStrip1.Items)
          _button.Checked = _button == e.ClickedItem;
      }
    }
    
  }
}
