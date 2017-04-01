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
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // Showing second form nearby this form
      this.SetDesktopLocation(this.Width / 2, this.DesktopLocation.Y / 2);
      var _frm2 = new Form2();
      _frm2.Show();
      Point location = this.DesktopLocation;
      location.Offset(this.DesktopBounds.Size.Width + 2, 0);
      _frm2.SetDesktopLocation(location.X, location.Y);
    }
  }
}
