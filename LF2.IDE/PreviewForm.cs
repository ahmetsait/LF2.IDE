using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LF2.IDE
{
	public partial class PreviewForm : Form
	{
		public PreviewForm()
		{
			InitializeComponent();
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
		}

		protected override bool ShowWithoutActivation
		{
			get { return true; }
		}

		private const int WM_NCACTIVATE = 0x6;

		protected override void WndProc(ref Message m)
		{
			base.WndProc(ref m);
			if (m.Msg == WM_NCACTIVATE) this.Owner.Focus();
		}

		public void Set(Image image, Point location, int timeout)
		{
			if (pictureBox.Image != null) pictureBox.Image.Dispose();
			this.pictureBox.Image = image;
			this.timer.Stop();
			this.timer.Interval = timeout;
			this.timer.Start();
			this.Location = location;
		}

		public void Set(Point location, int timeout)
		{
			this.timer.Stop();
			this.timer.Interval = timeout;
			this.timer.Start();
			this.Location = location;
		}

		void TimerTick(object sender, EventArgs e)
		{
			this.Close();
		}

		void PreviewFormLoad(object sender, EventArgs e)
		{
			timer.Start();
		}
	}
}
