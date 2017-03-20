using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D; 
using System.Runtime.InteropServices;

namespace CanadianBeaver.Components
{
  public partial class HeaderTableLayoutPanel : System.Windows.Forms.TableLayoutPanel
  {
    [Browsable(true)]
    public new string Text
    {
      get { return base.Text; }
      set
      {
        base.Text = value;
        this.CalculateTextHeight();
        Invalidate();
      }
    }

    [Browsable(true), DefaultValue(true)]
    public bool IsHighlightText
    {
      get { return this.isHighlightText; }
      set
      {
        this.isHighlightText = value;
        this.CalculateTextHeight();
        Invalidate();
      }
    }
    private bool isHighlightText = true;


    private int textHeight; // storing the Height value of Text for caching
    private void CalculateTextHeight()
    {
      using (var g = this.CreateGraphics())
        this.textHeight = g.MeasureString(this.Text, this.Font).ToSize().Height;
    }

    public override Rectangle DisplayRectangle
    {
      get
      {
        var result = base.DisplayRectangle;
        int resize = this.textHeight + 4;
        result.Height -= resize;
        result.Offset(0, resize);
        return result;
      }
    }

    protected override Size SizeFromClientSize(Size clientSize)
    {
      var result = base.SizeFromClientSize(clientSize);
      int resize = this.textHeight + 4;
      result.Height += resize;
      return result;
    }

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);
      this.CalculateTextHeight();
      Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      float lineWidth = this.isHighlightText ? 2 : 1;
      using (Brush textBrush = new SolidBrush(this.isHighlightText ? SystemColors.MenuHighlight : this.ForeColor))
        e.Graphics.DrawString(this.Text, this.Font, textBrush, 0, 0);
      using (Brush aGradientBrush = new LinearGradientBrush(new Point(0, 0), new Point(this.Width, 0), this.isHighlightText ? SystemColors.Highlight : this.ForeColor, this.isHighlightText ? SystemColors.ControlLight : this.BackColor))
      using (Pen aGradientPen = new Pen(aGradientBrush, lineWidth))
        e.Graphics.DrawLine(aGradientPen, 0, this.textHeight + lineWidth, this.Width, this.textHeight + lineWidth);
    }
    
  }
}
