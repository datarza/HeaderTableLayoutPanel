# TableLayoutPanel with highlighted header

This is WinForms highlighted header control based on TableLayoutPanel

![Demonstrative image](img_01.png "Demonstrative image")


## Problem

There are a lot of panels for grouping the controls in WinForms. The best one of them is TableLayoutPanel. Unfortunately, this panel does not show the Header.

## Solution

It can be solved by GroupBox and TableLayoutPanel. This solution is easy, but I prefer to make inherited panel from TableLayoutPanel.

## How It Works

The HeaderTableLayoutPanel implements the IsHighlightText property and overrides the few properties like Text, DisplayRectangle and SizeFromClientSize. Also, the HeaderTableLayoutPanel overrides the OnPaint and OnFontChanged methods.



