using System;
using System.Drawing;
using System.Windows.Forms;

namespace LF2.IDE
{
	public partial class FormReziseTexture : Form
	{
		public FormReziseTexture(int w, int h)
		{
			InitializeComponent();
			textBox_Width.Text = (width = w).ToString();
			textBox_Height.Text = (height = h).ToString();
		}

		public int width;
		public int height;

		void ButtonOKClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		void ButtonCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		void WBoxValidating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				width = int.Parse(textBox_Width.Text);
			}
			catch
			{
				e.Cancel = true;
			}
		}

		void HBoxValidating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				height = int.Parse(textBox_Height.Text);
			}
			catch
			{
				e.Cancel = true;
			}
		}
	}
}
