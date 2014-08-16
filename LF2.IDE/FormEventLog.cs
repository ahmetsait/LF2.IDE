using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LF2.IDE
{
	public partial class FormEventLog : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		public FormEventLog()
		{
			InitializeComponent();
		}

		public void Error(Exception ex, string title)
		{
			string error = ex.ToString();
			MessageBox.Show(error, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
			try
			{
				Log(error, title, true);
			}
			catch { }
		}

		public uint Log(string logMessage, string logTitle, bool stepCaret)
		{
			uint caret = (uint)Log(">>\t" + logTitle, false);
			richTextBox.AppendText("\r\n");
			richTextBox.AppendText(logMessage);
			if (stepCaret)
			{
				richTextBox.SelectionStart = (int)caret;
				richTextBox.ScrollToCaret();
			}
			return caret;
		}

		public uint Log(string logMessage, bool stepCaret)
		{
			if (!string.IsNullOrEmpty(richTextBox.Text))
				richTextBox.AppendText("\r\n\r\n");
			uint caret = (uint)richTextBox.Text.Length;
			richTextBox.AppendText(logMessage);
			if (stepCaret)
			{
				richTextBox.SelectionStart = (int)caret;
				richTextBox.ScrollToCaret();
			}
			return caret;
		}

		public void Clean()
		{
			richTextBox.Clear();
		}

		void RichTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}
	}
}
