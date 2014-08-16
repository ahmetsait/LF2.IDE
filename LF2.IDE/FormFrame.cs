using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

namespace LF2.IDE
{
	public partial class FormFrame : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		public FormFrame(MainForm main)
		{
			mainForm = main;
			InitializeComponent();
		}

		MainForm mainForm;

		void ImageIndexChanged(object sender, EventArgs e)
		{
			if (mainForm.lastActiveFrame != null)
				drawBox.Image = mainForm.lastActiveFrame[mainForm.lastActiveDoc.frameIndexFrame = (int)numericUoDown_imageIndex.Value];

			numericUoDown_imageIndex.Refresh();
		}

		private void Insert(object sender, EventArgs e)
		{
			if (mainForm.ActiveDocument != null)
				mainForm.ActiveDocument.Scintilla.Selection.Text = richTextBox.Text;
		}

		private void Generate(object sender, EventArgs e)
		{
			int nextStep; int.TryParse(next.Text.Trim(), out nextStep);
			string str = "<frame> " + numericUpDown_frameIndex.Value + " " + ComboBox_caption.Text.Trim() + "\n   " + "pic: " + numericUoDown_imageIndex.Value + "  state: " + state.Text.Trim() + "  wait: " + wait.Text.Trim() + "  next: " + next.Text.Trim() + "  dvx: " + dvx.Text.Trim() + "  dvy: " + dvy.Text.Trim() + (dvz.Text != "" ? "  dvz: " + dvz.Text.Trim() : "") + "  centerx: " + centerx.Text.Trim() + "  centery: " + centery.Text.Trim();
			str += hit_a.Text.Trim() == "" ? "" : "  hit_a: " + hit_a.Text.Trim();
			str += hit_d.Text.Trim() == "" ? "" : "  hit_d: " + hit_d.Text.Trim();
			str += hit_j.Text.Trim() == "" ? "" : "  hit_j: " + hit_j.Text.Trim();
			str += hit_Fa.Text.Trim() == "" ? "" : "  hit_Fa: " + hit_Fa.Text.Trim();
			str += hit_Ua.Text.Trim() == "" ? "" : "  hit_Ua: " + hit_Ua.Text.Trim();
			str += hit_Da.Text.Trim() == "" ? "" : "  hit_Da: " + hit_Da.Text.Trim();
			str += hit_Fj.Text.Trim() == "" ? "" : "  hit_Fj: " + hit_Fj.Text.Trim();
			str += hit_Uj.Text.Trim() == "" ? "" : "  hit_Uj: " + hit_Uj.Text.Trim();
			str += hit_Dj.Text.Trim() == "" ? "" : "  hit_Dj: " + hit_Dj.Text.Trim();
			str += hit_ja.Text.Trim() == "" ? "" : "  hit_ja: " + hit_ja.Text.Trim();
			str += sound.Text.Trim() == "" ? "" : "\n  sound: " + sound.Text.Trim();
			if (checkBox_AddTags.Checked && mainForm.formTag.richTextBox.Text != "") str += "\n" + mainForm.formTag.richTextBox.Text;
			str += "\n<frame_end>";

			if (frameCount.Value > 1)
			{
				for (int i = 1; i < frameCount.Value; i++)
				{
					str += "\n\n<frame> " + (numericUpDown_frameIndex.Value + i) + " " + ComboBox_caption.Text.Trim() + "\n   " + "pic: " + (numericUoDown_imageIndex.Value + i) + "  state: " + state.Text.Trim() + "  wait: " + wait.Text.Trim() + "  next: " + (i == frameCount.Value - 1 ? nextOfLastFrame.Text : (nextStep + i).ToString()) + "  dvx: " + dvx.Text.Trim() + "  dvy: " + dvy.Text.Trim() + (dvz.Text != "" ? "  dvz: " + dvz.Text.Trim() : "") + "  centerx: " + centerx.Text.Trim() + "  centery: " + centery.Text.Trim();
					str += hit_a.Text.Trim() == "" ? "" : "  hit_a: " + hit_a.Text.Trim();
					str += hit_d.Text.Trim() == "" ? "" : "  hit_d: " + hit_d.Text.Trim();
					str += hit_j.Text.Trim() == "" ? "" : "  hit_j: " + hit_j.Text.Trim();
					str += hit_Fa.Text.Trim() == "" ? "" : "  hit_Fa: " + hit_Fa.Text.Trim();
					str += hit_Ua.Text.Trim() == "" ? "" : "  hit_Ua: " + hit_Ua.Text.Trim();
					str += hit_Da.Text.Trim() == "" ? "" : "  hit_Da: " + hit_Da.Text.Trim();
					str += hit_Fj.Text.Trim() == "" ? "" : "  hit_Fj: " + hit_Fj.Text.Trim();
					str += hit_Uj.Text.Trim() == "" ? "" : "  hit_Uj: " + hit_Uj.Text.Trim();
					str += hit_Dj.Text.Trim() == "" ? "" : "  hit_Dj: " + hit_Dj.Text.Trim();
					str += hit_ja.Text.Trim() == "" ? "" : "  hit_ja: " + hit_ja.Text.Trim();
					str += sound.Text.Trim() == "" ? "" : "\n  sound: " + sound.Text.Trim();
					if (checkBox_AddTags.Checked && mainForm.formTag.richTextBox.Text != "") str += "\n" + mainForm.formTag.richTextBox.Text;
					str += "\n<frame_end>";
				}
			}

			if (string.IsNullOrEmpty(richTextBox.Text))
				richTextBox.Text = str;
			else
				richTextBox.Text += "\n\n" + str;

			richTextBox.SelectionStart = richTextBox.Text.Length;
			richTextBox.ScrollToCaret();
		}

		private void NextMinus(object sender, EventArgs e)
		{
			next.Text = nextMinus.Text;
		}

		private void NextPlus(object sender, EventArgs e)
		{
			next.Text = nextPlus.Text;
		}

		void RichTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.V && e.Control)
			{
				(sender as RichTextBox).Paste(DataFormats.GetFormat(DataFormats.UnicodeText));
				e.Handled = true;
			}
		}

		void CopyToClipboard(object sender, EventArgs e)
		{
			if (richTextBox.Text != "")
				Clipboard.SetText(richTextBox.Text);
		}

		void NewLine(object sender, EventArgs e)
		{
			if (mainForm.ActiveDocument != null)
				mainForm.ActiveDocument.Scintilla.Selection.Text = (mainForm.ActiveDocument.Scintilla.EndOfLine.Mode == ScintillaNET.EndOfLineMode.LF ? "\n" : "\r\n");
		}

		void FormVisualFormClosing(object sender, FormClosingEventArgs e)
		{

		}

		void Clear(object sender, EventArgs e)
		{
			richTextBox.Text = "";
		}

		void FrameIndexChanged(object sender, EventArgs e)
		{
			nextMinus.Text = (numericUpDown_frameIndex.Value - 1).ToString();
			nextPlus.Text = (numericUpDown_frameIndex.Value + 1).ToString();
		}
	}
}
