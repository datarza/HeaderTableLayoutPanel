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
      this.SetDesktopLocation(this.DesktopLocation.X - this.Width, this.DesktopLocation.Y);
      var frm = new Form2();
      frm.Show();
      Point location = this.DesktopLocation;
      location.Offset(this.DesktopBounds.Size.Width + 1, 0);
      frm.SetDesktopLocation(location.X, location.Y);
    }
  }
}
