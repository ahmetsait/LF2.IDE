using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Media;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.Win32;
using DrawBox;

namespace LF2.IDE
{
	public partial class FormShape : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		public FormShape(MainForm main)
		{
			mainForm = main;
			InitializeComponent();
		}

		void FormShapeLoad(object sender, EventArgs e)
		{
			drawBox.Cursor = new Cursor(Properties.Resources.wpoint.GetHicon());
		}

		MainForm mainForm;

		void Add(object sender, EventArgs e)
		{
			if (mainForm.ActiveDocument != null)
				mainForm.ActiveDocument.Scintilla.Selection.Text = richTextBox.Text;
		}

		void ImageIndexChanged(object sender, EventArgs e)
		{
			if (mainForm.lastActiveFrame != null)
				drawBox.Image = mainForm.lastActiveFrame[mainForm.lastActiveDoc.frameIndexShape = (int)numericUpDown_ImageIndex.Value];

			numericUpDown_ImageIndex.Refresh();
			drawBox.Refresh();
		}

		void ShapeChanged(object sender, EventArgs e)
		{
			if (radioButton_Point.Checked)
			{
				drawBox.DrawingMode = DrawingMode.Point;
				drawBox.DisplayMode = DisplayModes.Point;
			}
			else if (radioButton_Vector.Checked)
			{
				drawBox.DrawingMode = DrawingMode.Vector;
				drawBox.DisplayMode = DisplayModes.Vector;
			}
			else if (radioButton_Rectangle.Checked)
			{
				drawBox.DrawingMode = DrawingMode.Rectangle;
				drawBox.DisplayMode = DisplayModes.Rectangle;
			}
			else if (radioButton_Zwidth.Checked)
			{
				drawBox.DrawingMode = DrawingMode.Zwidth;
				drawBox.DisplayMode = DisplayModes.Zwidth;
			}
			else if (radioButton_Center.Checked)
			{
				drawBox.DrawingMode = DrawingMode.Center;
				drawBox.DisplayMode = DisplayModes.Center;
			}
			else
			{
				drawBox.DrawingMode = DrawingMode.None;
				drawBox.DisplayMode = DisplayModes.None;
			}

			if (checkBox_AutoGenerate.Checked)
				button_Generate.PerformClick();
		}

		void RichTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.V && e.Control)
			{
				(sender as RichTextBox).Paste(DataFormats.GetFormat(DataFormats.UnicodeText));
				e.Handled = true;
			}
		}

		void AutoGenerate(object sender, EventArgs e)
		{
			if (checkBox_AutoGenerate.Checked)
				button_Generate.PerformClick();
		}

		void Generate(object sender, EventArgs e)
		{
			switch (drawBox.DrawingMode)
			{
				case DrawingMode.Point:
					richTextBox.Text = "x: " + drawBox.Point.X + "  y: " + drawBox.Point.Y;
					break;
				case DrawingMode.Vector:
					richTextBox.Text = "dvx: " + drawBox.Vector.X + "  dvy: " + drawBox.Vector.Y;
					break;
				case DrawingMode.Rectangle:
					richTextBox.Text = "x: " + drawBox.Rectangle.X + "  y: " + drawBox.Rectangle.Y + "  w: " + drawBox.Rectangle.Width + "  h: " + drawBox.Rectangle.Height;
					break;
				case DrawingMode.Zwidth:
					richTextBox.Text = "zwidth: " + drawBox.Zwidth;
					break;
				case DrawingMode.Center:
					richTextBox.Text = "centerx: " + drawBox.Center.X + "  centery: " + drawBox.Center.Y;
					break;
			}
			richTextBox.Refresh();
			drawBox.Refresh();
		}

		void CopyToClipboard(object sender, EventArgs e)
		{
			if (richTextBox.Text != "")
				Clipboard.SetText(richTextBox.Text);
		}
	}
}
