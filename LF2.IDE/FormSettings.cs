using System.Security.Principal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LF2.IDE
{
	public partial class FormSettings : Form
	{
		public FormSettings()
		{
			InitializeComponent();
		}

		void FormSetLoad(object sender, EventArgs e)
		{
			textBox_EncryptionKey.Text = Settings.Default.encryptionKey;
			textBox_DecryptionKey.Text = Settings.Default.decryptionKey;
			textBox_Path.Text = (string.IsNullOrEmpty(Settings.Default.lfPath) ? "lf2.exe" : Settings.Default.lfPath);
			radioButton_External.Checked = !(radioButton_Default.Checked = string.IsNullOrEmpty(Settings.Default.dataUtil));
			if (UtilManager.Utils != null)
			{
				foreach (string key in UtilManager.Utils.Keys)
					comboBox_DataUtils.Items.Add(key);
				comboBox_DataUtils.SelectedItem = Settings.Default.dataUtil;
			}
			ActiveControl = textBox_Path;
			textBox_Path.Focus();
		}

		void LookUp(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
				textBox_Path.Text = (string)openFileDialog.FileName;
		}

		void OK(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		void Cancel(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		void FormSetFormClosed(object sender, FormClosedEventArgs e)
		{
			if (this.DialogResult == DialogResult.OK)
			{
				Settings.Default.encryptionKey = textBox_EncryptionKey.Text;
				Settings.Default.decryptionKey = textBox_DecryptionKey.Text;
				Settings.Default.lfPath = (string.IsNullOrEmpty(textBox_Path.Text) ? "lf2.exe" : textBox_Path.Text);
				Settings.Default.dataUtil = (radioButton_Default.Checked || string.IsNullOrEmpty(comboBox_DataUtils.Text)) ? null : comboBox_DataUtils.Text;
			}
		}
	}
}
