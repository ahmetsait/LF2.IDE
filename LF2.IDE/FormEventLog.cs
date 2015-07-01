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
				this.Invoke((Action)(() => MessageBox.Show(error, "[Async] " + title, MessageBoxButtons.OK, MessageBoxIcon.Error)));
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
			Action act = (Action)(() =>
				{
					Log(">>\t" + logTitle, false);
					int caret = richTextBox.Text.Length;
					richTextBox.AppendText(Environment.NewLine + logMessage);
					StepCaret(stepCaret);
				});

			if (this.InvokeRequired)
				this.Invoke(act);
			else
				act();
		}

		public void Log(string logMessage, bool stepCaret)
		{
			Action act = (Action)(() =>
				{
					if (!string.IsNullOrEmpty(richTextBox.Text))
						richTextBox.AppendText(System.Environment.NewLine + System.Environment.NewLine);
					richTextBox.AppendText(logMessage);
					StepCaret(stepCaret);
				});

			if (richTextBox.InvokeRequired)
				richTextBox.Invoke(act);
			else
				act();
		}

		private void StepCaret(bool condition)
		{
			if (condition)
			{
				richTextBox.Select(richTextBox.Text.Length, 0);
				richTextBox.ScrollToCaret();
				richTextBox.Update();
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
