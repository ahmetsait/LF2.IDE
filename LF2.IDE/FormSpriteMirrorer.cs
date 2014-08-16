using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LF2.IDE
{
	public partial class FormSpriteMirrorer : Form
	{
		MainForm mainForm;

		public FormSpriteMirrorer(Bitmap img, string path, MainForm main)
		{
			InitializeComponent();
			mainForm = main;
			allowedFormats.Add(PixelFormat.Format16bppRgb555);
			allowedFormats.Add(PixelFormat.Format16bppRgb565);
			allowedFormats.Add(PixelFormat.Format24bppRgb);
			allowedFormats.Add(PixelFormat.Format32bppArgb);
			allowedFormats.Add(PixelFormat.Format32bppPArgb);
			allowedFormats.Add(PixelFormat.Format32bppRgb);
			allowedFormats.Add(PixelFormat.Format48bppRgb);
			allowedFormats.Add(PixelFormat.Format64bppArgb);
			allowedFormats.Add(PixelFormat.Format64bppPArgb);

			foreach (string rft in RotateFlipType.GetNames(typeof(RotateFlipType)))
				comboBox_Mode.Items.Add(rft);

			if (!allowedFormats.Contains(img.PixelFormat))
			{
				bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppRgb);
				using (Graphics g = Graphics.FromImage(bmp))
					g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
				drawBox_OriginalSprite.Image = original = (Bitmap)bmp.Clone();
				drawBox_ModifedSprite.Image = bmp;

			}
			else
			{
				drawBox_OriginalSprite.Image = original = (Bitmap)img.Clone();
				drawBox_ModifedSprite.Image = bmp = (Bitmap)original.Clone();
			}
			this.path = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + "_mirror" + Path.GetExtension(path);
		}

		Bitmap bmp;
		readonly Bitmap original;
		string path;

		readonly List<PixelFormat> allowedFormats = new List<PixelFormat>(9);

		void FormMirrorerLoad(object sender, EventArgs e)
		{
			comboBox_Mode.SelectedItem = "RotateNoneFlipX";
		}

		void ComboBoxModeSelectedIndexChanged(object sender, EventArgs e)
		{
			drawBox_ModifedSprite.AutoRefresh = false;
			(drawBox_ModifedSprite.Image = bmp = (Bitmap)original.Clone()).RotateFlip((RotateFlipType)RotateFlipType.Parse(typeof(RotateFlipType), (string)comboBox_Mode.SelectedItem));
			drawBox_ModifedSprite.AutoRefresh = true;
		}

		void ButtonApplyClick(object sender, EventArgs e)
		{
			FormImageSaver saver = new FormImageSaver(bmp, path, false, mainForm);
			saver.ShowDialog();
		}
	}
}
