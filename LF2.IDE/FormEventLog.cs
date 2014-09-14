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

			if (this.InvokeRequired)
				this.Invoke((Action)(() => MessageBox.Show(error, title, MessageBoxButtons.OK, MessageBoxIcon.Error)));
			else
				MessageBox.Show(error, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
			try
			{
				Log(error, title, true);
			}
			catch { }
		}

		public void Log(string logMessage, string logTitle, bool stepCaret)
		{
			if (this.InvokeRequired)
				this.Invoke((Action)(() =>
				{
					Log(">>\t" + logTitle, false);
					int caret = richTextBox.Text.Length;
					richTextBox.AppendText("\r\n" + logMessage);
					if (stepCaret)
					{
						richTextBox.SelectionStart = caret;
						richTextBox.ScrollToCaret();
					}
				}));
			else
			{
				Log(">>\t" + logTitle, false);
				int caret = richTextBox.Text.Length;
				richTextBox.AppendText("\r\n" + logMessage);
				if (stepCaret)
				{
					richTextBox.SelectionStart = caret;
					richTextBox.ScrollToCaret();
				}
			}
		}

		public void Log(string logMessage, bool stepCaret)
		{
			if (this.InvokeRequired)
				this.Invoke((Action)(() =>
				{
					if (!string.IsNullOrEmpty(richTextBox.Text))
						richTextBox.AppendText("\r\n\r\n");
					richTextBox.AppendText(logMessage);
					if (stepCaret)
					{
						richTextBox.SelectionStart = richTextBox.Text.Length;
						richTextBox.ScrollToCaret();
					}
				}));
			else
			{
				if (!string.IsNullOrEmpty(richTextBox.Text))
					richTextBox.AppendText("\r\n\r\n");
				richTextBox.AppendText(logMessage);
				if (stepCaret)
				{
					richTextBox.SelectionStart = richTextBox.Text.Length;
					richTextBox.ScrollToCaret();
				}
			}
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
