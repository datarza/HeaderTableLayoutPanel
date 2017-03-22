using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D; 
using System.Runtime.InteropServices;

namespace CBComponents
{
  public class HeaderTableLayoutPanel : System.Windows.Forms.TableLayoutPanel
  {
    [Browsable(true), DefaultValue(null)]
    public string Caption
    {
      get { return this.caption; }
      set
      {
        if (this.caption != value)
        {
          this.caption = value;
          this.CalculateCaptionParams();
          Invalidate();
        }
      }
    }
    private string caption = null;

    public enum HighlightCaptionStyle
    {
      ForeColor, HighlightColor, HighlightStyle, NavisionAxaptaStyle
    }

    [Browsable(true), DefaultValue(HighlightCaptionStyle.ForeColor)]
    public HighlightCaptionStyle CaptionStyle
    {
      get { return this.captionMode; }
      set
      {
        if (this.captionMode != value)
        {
          this.captionMode = value;
          this.CalculateCaptionParams();
          Invalidate();
        }
      }
    }
    private HighlightCaptionStyle captionMode = HighlightCaptionStyle.ForeColor;

    [Browsable(true), DefaultValue((byte)2)]
    public byte CaptionLineWidth
    {
      get { return this.captionLineWidth; }
      set
      {
        if (this.captionLineWidth != value)
        {
          this.captionLineWidth = value > (byte)22 ? (byte)22 : value;
          this.CalculateCaptionParams();
          Invalidate();
        }
      }
    }
    private byte captionLineWidth = 2;
        
    protected override void OnForeColorChanged(EventArgs e)
    {
      base.OnForeColorChanged(e);
      this.CalculateCaptionParams();
      Invalidate();
    }

    protected override void OnBackColorChanged(EventArgs e)
    {
      base.OnBackColorChanged(e);
      this.CalculateCaptionParams();
      Invalidate();
    }

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);
      this.CalculateCaptionParams();
      Invalidate();
    }

    // calculating and storing params 
    private int captionTextWidth;
    private int captionTextHeight;
    private Color captionTextColor;
    private Color captionGBColor;
    private Color captionGEColor;
    private void CalculateCaptionParams()
    {
      if (!string.IsNullOrEmpty(this.Caption))
        using (var g = this.CreateGraphics())
        {
          var _size = g.MeasureString(this.Caption, this.Font).ToSize();
          this.captionTextWidth = _size.Width;
          this.captionTextHeight = _size.Height;
        }
      else
      {
        this.captionTextWidth = 0;
        this.captionTextHeight = 0;
      }
      if (this.captionMode == HighlightCaptionStyle.ForeColor)
      {
        this.captionTextColor = this.ForeColor;
        this.captionGBColor = this.ForeColor;
        this.captionGEColor = this.BackColor;
      }
      else
      {
        this.captionTextColor = this.captionMode == HighlightCaptionStyle.HighlightStyle ? SystemColors.HighlightText : SystemColors.Highlight;
        this.captionGBColor = SystemColors.MenuHighlight;
        this.captionGEColor = this.BackColor; 
      }
    }

    public override Rectangle DisplayRectangle
    {
      get
      {
        var result = base.DisplayRectangle;
        int resize = 0;
        if (this.captionTextHeight > 0) resize = this.captionTextHeight + 2;
        if (this.captionMode == HighlightCaptionStyle.HighlightStyle) resize += this.captionLineWidth * 2;
        else if (this.captionMode != HighlightCaptionStyle.NavisionAxaptaStyle) resize += this.captionLineWidth;
        result.Height -= resize;
        result.Offset(0, resize);
        return result;
      }
    }

    protected override Size SizeFromClientSize(Size clientSize)
    {
      var result = base.SizeFromClientSize(clientSize);
      int resize = 0;
      if (this.captionTextHeight > 0) resize = this.captionTextHeight + 2;
      if (this.captionMode == HighlightCaptionStyle.HighlightStyle) resize += this.captionLineWidth * 2;
      else if (this.captionMode != HighlightCaptionStyle.NavisionAxaptaStyle) resize += this.captionLineWidth;
      result.Height += resize;
      return result;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      // draw gradient
      if (this.captionMode == HighlightCaptionStyle.HighlightStyle)
      { // HighlightCaptionStyle.HighlightStyle allways draw
        using (Brush _gradientBrush = new LinearGradientBrush(new Point(0, 0), new Point(this.Width, 0), this.captionGBColor, this.captionGEColor))
        using (Pen _gradientPen = new Pen(_gradientBrush, this.captionLineWidth * 2 + this.captionTextHeight))
          e.Graphics.DrawLine(_gradientPen, 0, _gradientPen.Width / 2, this.Width, _gradientPen.Width / 2);
      }
      else if (this.captionLineWidth > 0)
        if (this.captionMode != HighlightCaptionStyle.NavisionAxaptaStyle)
        { // HighlightCaptionMode.ForeColor | HighlightCaptionMode.SystemColorsHighlight
          using (Brush _gradientBrush = new LinearGradientBrush(new Point(0, 0), new Point(this.Width, 0), this.captionGBColor, this.captionGEColor))
          using (Pen _gradientPen = new Pen(_gradientBrush, this.captionLineWidth))
            e.Graphics.DrawLine(_gradientPen, 0, this.captionTextHeight + this.captionLineWidth / 2, this.Width, this.captionTextHeight + this.captionLineWidth / 2);
        }
        else if (this.captionTextWidth + 1 < this.Width)
        { // HighlightCaptionMode.NavisionAxapta
          using (Brush _gradientBrush = new LinearGradientBrush(new Point(this.captionTextWidth, 0), new Point(this.Width, 0), this.captionGBColor, this.captionGEColor))
          using (Pen _gradientPen = new Pen(_gradientBrush, this.captionLineWidth > this.captionTextHeight ? this.captionTextHeight : this.captionLineWidth))
            e.Graphics.DrawLine(_gradientPen, this.captionTextWidth, this.captionTextHeight / 2 + 1, this.Width, this.captionTextHeight / 2 + 1);
        }
      // draw Text
      if (this.captionTextHeight > 0)
        using (Brush _textBrush = new SolidBrush(this.captionTextColor))
          e.Graphics.DrawString(this.Caption, this.Font, _textBrush, 0, this.captionMode == HighlightCaptionStyle.HighlightStyle ? this.CaptionLineWidth : 0);
    }

  }
}
