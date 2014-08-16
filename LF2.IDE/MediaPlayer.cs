using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using Microsoft.Win32;
using System.Security.Principal;

namespace LF2.IDE
{
	public partial class MediaPlayer : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		public MediaPlayer()
		{
			InitializeComponent();
		}

		void OpenFileButtonClick(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				axWindowsMediaPlayer.URL = openFileDialog.FileName;
			}
			this.Show();
		}
	}
}
