using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace LF2.IDE
{
	public partial class FormImageSaver : Form
	{
		MainForm mainForm;

		public FormImageSaver(Bitmap img, string path, bool checkFormat, MainForm main)
		{
			InitializeComponent();
			mainForm = main;
			if (checkFormat)
			{
				List<PixelFormat> allowedFormats = new List<PixelFormat>(9);

				allowedFormats.Add(PixelFormat.Format16bppRgb555);
				allowedFormats.Add(PixelFormat.Format16bppRgb565);
				allowedFormats.Add(PixelFormat.Format24bppRgb);
				allowedFormats.Add(PixelFormat.Format32bppArgb);
				allowedFormats.Add(PixelFormat.Format32bppPArgb);
				allowedFormats.Add(PixelFormat.Format32bppRgb);
				allowedFormats.Add(PixelFormat.Format48bppRgb);
				allowedFormats.Add(PixelFormat.Format64bppArgb);
				allowedFormats.Add(PixelFormat.Format64bppPArgb);

				if (!allowedFormats.Contains(img.PixelFormat))
				{
					bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppRgb);
					using (Graphics g = Graphics.FromImage(bmp))
						g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
				}
				else
					bmp = (Bitmap)img.Clone();
			}
			else
				bmp = (Bitmap)img.Clone();

			propertyGrid.SelectedObject = bmp;

			comboBoxPixelFormat.Items.Add(PixelFormat.Format16bppRgb555);
			comboBoxPixelFormat.Items.Add(PixelFormat.Format16bppRgb565);
			comboBoxPixelFormat.Items.Add(PixelFormat.Format24bppRgb);
			comboBoxPixelFormat.Items.Add(PixelFormat.Format32bppArgb);
			comboBoxPixelFormat.Items.Add(PixelFormat.Format32bppPArgb);
			comboBoxPixelFormat.Items.Add(PixelFormat.Format32bppRgb);
			comboBoxPixelFormat.Items.Add(PixelFormat.Format48bppRgb);
			comboBoxPixelFormat.Items.Add(PixelFormat.Format64bppArgb);
			comboBoxPixelFormat.Items.Add(PixelFormat.Format64bppPArgb);

			comboBoxPixelFormat.SelectedItem = bmp.PixelFormat;
			comboBoxImageFormat.SelectedIndex = 0;

			saveFileDialog.InitialDirectory = Path.GetDirectoryName(this.path = path);
		}

		Bitmap bmp;
		string path;

		void ButtonOKClick(object sender, EventArgs e)
		{
			saveFileDialog.FileName = Path.GetFileNameWithoutExtension(path);
			saveFileDialog.FilterIndex = Math.Max(1, comboBoxImageFormat.SelectedIndex);

			if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

			try
			{
				PixelFormat px = (PixelFormat)comboBoxPixelFormat.SelectedItem;

				switch (comboBoxImageFormat.SelectedIndex)
				{
					case 0:
						using (Bitmap image = new Bitmap(bmp.Width, bmp.Height, px))
						{
							using (Graphics g = Graphics.FromImage(image))
							{
								g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
							}
							image.Save(saveFileDialog.FileName, ImageFormat.Bmp);
						}
						break;
					case 1:
						using (Bitmap image = new Bitmap(bmp.Width, bmp.Height, px))
						{
							using (Graphics g = Graphics.FromImage(image))
							{
								g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
							}
							image.Save(saveFileDialog.FileName, ImageFormat.MemoryBmp);
						}
						break;
					case 2:
						using (Bitmap image = new Bitmap(bmp.Width, bmp.Height, px))
						{
							using (Graphics g = Graphics.FromImage(image))
							{
								g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
							}
							image.Save(saveFileDialog.FileName, ImageFormat.Png);
						}
						break;
					case 3:
						using (Bitmap image = new Bitmap(bmp.Width, bmp.Height, px))
						{
							using (Graphics g = Graphics.FromImage(image))
							{
								g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
							}
							image.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
						}
						break;
					case 4:
						using (Bitmap image = new Bitmap(bmp.Width, bmp.Height, px))
						{
							using (Graphics g = Graphics.FromImage(image))
							{
								g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
							}
							image.Save(saveFileDialog.FileName, ImageFormat.Gif);
						}
						break;
					case 5:
						using (Bitmap image = new Bitmap(bmp.Width, bmp.Height, px))
						{
							using (Graphics g = Graphics.FromImage(image))
							{
								g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
							}
							image.Save(saveFileDialog.FileName, ImageFormat.Emf);
						}
						break;
					case 6:
						using (Bitmap image = new Bitmap(bmp.Width, bmp.Height, px))
						{
							using (Graphics g = Graphics.FromImage(image))
							{
								g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
							}
							image.Save(saveFileDialog.FileName, ImageFormat.Tiff);
						}
						break;
					case 7:
						using (Bitmap image = new Bitmap(bmp.Width, bmp.Height, px))
						{
							using (Graphics g = Graphics.FromImage(image))
							{
								g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
							}
							image.Save(saveFileDialog.FileName, ImageFormat.Wmf);
						}
						break;
				}
			}
			catch (Exception ex)
			{
				mainForm.formEventLog.Error(ex, "ERROR");
				return;
			}
			this.DialogResult = DialogResult.OK;
		}

		void ButtonCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
