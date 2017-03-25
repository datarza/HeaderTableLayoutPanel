## Problem

There are a lot of panels for grouping the controls in WinForms. The best one of them is _TableLayoutPanel_, especially for grouping controls, that are using for editing data. Unfortunately, this panel does not show the header. This necessity appears when there are different kinds of editing controls on the same Windows form.

## Solution

It can be solved by _GroupBox_ and _TableLayoutPanel_. This solution is easy, but may look unpleasant. Another possibility is using Label control in first row of _TableLayoutPanel_. This solution may be uncomfortable.

I prefer to make inherited panel from _TableLayoutPanel_ with all necessary functions.

# TableLayoutPanel with highlighted header

![Demonstrative image](img_01.png) 

## How It Works

The _HeaderTableLayoutPanel_ implements the _IsHighlightText_ property and overrides the few properties like _Text_, _DisplayRectangle_ and _SizeFromClientSize_. Also, the _HeaderTableLayoutPanel_ overrides the _OnPaint_ and _OnFontChanged_ methods.

![Demonstrative image](img_02.png)

![Demonstrative image](img_03.png)

![Demonstrative image](img_04.png)
