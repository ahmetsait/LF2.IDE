using ProtoBuf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LF2.IDE
{
	public partial class FormTag : WeifenLuo.WinFormsUI.Docking.DockContent
	{
		public FormTag(MainForm main)
		{
			mainForm = main;
			InitializeComponent();
			drawBox.Cursor = cur_bdy;
		}

		public Stopwatch stopWatch = new Stopwatch();

		MainForm mainForm;

		Image blood = Properties.Resources.blood, weaponactImage, vactionImage, vactionImageMirror;

		static readonly Cursor
			cur_bdy = new Cursor(Properties.Resources.bdy.GetHicon()),
			cur_itr = new Cursor(Properties.Resources.itr.GetHicon()),
			cur_w = new Cursor(Properties.Resources.wpoint.GetHicon()),
			cur_o = new Cursor(Properties.Resources.opoint.GetHicon()),
			cur_c = new Cursor(Properties.Resources.cpoint.GetHicon()),
			cur_b = new Cursor(Properties.Resources.bpoint.GetHicon());

		public static readonly Point[] weaponPoints =
		{
			new Point(29, 56),
			new Point(24, 40),
			new Point(17, 41),
			new Point(12, 37),
			new Point(9,  33),
			new Point(10, 29),
			new Point(12, 23),
			new Point(14, 15),
			new Point(17, 13),
			new Point(24, 11),
			new Point(29, 13),
			new Point(36, 16),
			new Point(37, 19),
			new Point(37, 26),
			new Point(38, 33),
			new Point(38, 33),
			new Point(34, 36),
			new Point(29, 40)
		};

		public static readonly int[,] caughtPoints =
		{
			{ 130, 53, 41, 39 },
			{ 131, 54, 41, 39 },
			{ 132, 55, 41, 39 },
			{ 133, 30, 33, 36 },
			{ 134, 31, 37, 28 },
			{ 135, 32, 31, 22 },
			{ 136, 33, 27, 46 },
			{ 137, 34, 33, 68 },
			{ 138, 35, 34, 54 },
			{ 139, 40, 40, 36 },
			{ 140, 41, 36, 38 },
			{ 141, 42, 44, 41 },
			{ 142, 43, 46, 51 },
			{ 143, 44, 45, 66 },
			{ 144, 45, 42, 55 }
		};

		string opointCachePath
		{
			get { return Path.GetDirectoryName(Settings.Current.lfPath) + "\\opoint.cache"; }
		}

		private void Add(object sender, EventArgs e)
		{
			if (mainForm.ActiveDocument != null)
			{
				int fend = mainForm.ActiveDocument.Scintilla.Text.IndexOf("<frame_end>", mainForm.ActiveDocument.Scintilla.CurrentPos);
				int fbegin = mainForm.ActiveDocument.Scintilla.Text.IndexOf("<frame>", mainForm.ActiveDocument.Scintilla.CurrentPos);
				if (fend >= 0 && (fbegin < 0 || fend < fbegin))
					mainForm.ActiveDocument.Scintilla.InsertText(fend, richTextBox.Text + "\n");
				else
					mainForm.ActiveDocument.Scintilla.Selection.Text = richTextBox.Text;
			}
		}

		private void Reset_Bdy(object sender, EventArgs e)
		{
			bdy_x.Text = bdy_y.Text = bdy_w.Text = bdy_h.Text = "";
		}

		private void Reset_Itr(object sender, EventArgs e)
		{
			itr_x.Text = itr_y.Text = itr_w.Text = itr_h.Text = itr_dvx.Text = itr_dvy.Text = "";
		}

		private void Reset_W(object sender, EventArgs e)
		{
			wpoint_x.Text = wpoint_y.Text = wpoint_dvx.Text = wpoint_dvy.Text = "";
		}

		//		private void Reset_O(object sender, EventArgs e)
		//		{
		//			opoint_x.Text = opoint_y.Text = opoint_dvx.Text = opoint_dvy.Text = "";
		//		}

		private void Reset_C(object sender, EventArgs e)
		{
			cpoint_y.Text = cpoint_throwvx.Text = cpoint_throwvy.Text = cpoint_x.Text = "";
		}

		private void Reset_B(object sender, EventArgs e)
		{
			bpoint_x.Text = bpoint_y.Text = "";
		}

		private void Generate(object sender, EventArgs e)
		{
			string txt = "";
			try
			{
				switch (tabControl_Tags.SelectedIndex)
				{
					case 0:
						txt = "   bdy:\n      kind: " + bdy_kind.Text + "  x: " + bdy_x.Text + "  y: " + bdy_y.Text + "  w: " + bdy_w.Text + "  h: " + bdy_h.Text + "\n   bdy_end:";
						break;
					case 1:
						txt = "   itr:\n      kind: " + itr_kind.Text;
						switch (itr_kind.Text)
						{
							case "0":
							case "6":
								txt += "  x: " + itr_x.Text + "  y: " + itr_y.Text + "  w: " + itr_w.Text + "  h: " + itr_h.Text + "  dvx: " + itr_dvx.Text + "  dvy: " + itr_dvy.Text + (itr_arest.Text != "" ? "  arest: " + itr_arest.Text : "") + (itr_vrest.Text != "" ? "  vrest: " + itr_vrest.Text : "") + (itr_fall.Text != "" ? "  fall: " + itr_fall.Text : "") + (itr_bdefend.Text == "" ? "" : "  bdefend: " + itr_bdefend.Text) + "  injury: " + itr_injury.Text + (itr_zwidth.Text == "" ? "" : "  zwidth: " + itr_zwidth.Text) + (itr_effect.Text == "" ? "" : "\n      effect: " + itr_effect.Text);
								break;
							case "1":
							case "3":
								txt += "  x: " + itr_x.Text + "  y: " + itr_y.Text + "  w: " + itr_w.Text + "  h: " + itr_h.Text + "  catchingact: " + itr_catchingact.Text + "  caughtact: " + itr_caughtact.Text;
								break;
							case "2":
							case "7":
							case "14":
								txt += "  x: " + itr_x.Text + "  y: " + itr_y.Text + "  w: " + itr_w.Text + "  h: " + itr_h.Text + (itr_arest.Text != "" ? "  arest: " + itr_arest.Text : "") + (itr_vrest.Text != "" ? "  vrest: " + itr_vrest.Text : "") + (itr_effect.Text == "" ? "" : "\n      effect: " + itr_effect.Text);
								break;
							case "4":
								txt += "  x: " + itr_x.Text + "  y: " + itr_y.Text + "  w: " + itr_w.Text + "  h: " + itr_h.Text + "  dvx: " + itr_dvx.Text + (itr_arest.Text != "" ? "  arest: " + itr_arest.Text : "") + (itr_vrest.Text != "" ? "  vrest: " + itr_vrest.Text : "") + (itr_fall.Text != "" ? "  fall: " + itr_fall.Text : "") + (itr_bdefend.Text == "" ? "" : "  bdefend: " + itr_bdefend.Text) + "  injury: " + itr_injury.Text;
								break;
							case "5":
								txt += "  x: " + itr_x.Text + "  y: " + itr_y.Text + "  w: " + itr_w.Text + "  h: " + itr_h.Text + "  dvx: 8  fall: 20  bdefend: 16  injury: 789";
								break;
							case "10":
							case "11":
								txt += "  x: " + itr_x.Text + "  y: " + itr_y.Text + "  w: " + itr_w.Text + "  h: " + itr_h.Text + (itr_arest.Text != "" ? "  arest: " + itr_arest.Text : "") + (itr_vrest.Text != "" ? "  vrest: " + itr_vrest.Text : "") + "  injury: " + itr_injury.Text + (itr_zwidth.Text == "" ? "" : "  zwidth: " + itr_zwidth.Text);
								break;
							case "15":
							case "16":
								txt += "  x: " + itr_x.Text + "  y: " + itr_y.Text + "  w: " + itr_w.Text + "  h: " + itr_h.Text + "  dvx: " + itr_dvx.Text + "  dvy: " + itr_dvy.Text + (itr_arest.Text != "" ? "  arest: " + itr_arest.Text : "") + (itr_vrest.Text != "" ? "  vrest: " + itr_vrest.Text : "") + (itr_fall.Text != "" ? "  fall: " + itr_fall.Text : "") + (itr_bdefend.Text == "" ? "" : "  bdefend: " + itr_bdefend.Text) + "  injury: " + itr_injury.Text + (itr_zwidth.Text == "" ? "" : "  zwidth: " + itr_zwidth.Text);
								break;
							case "8":
								txt += "  x: " + itr_x.Text + "  y: " + itr_y.Text + "  w: " + itr_w.Text + "  h: " + itr_h.Text + "  dvx: " + itr_dvx.Text + "  injury: " + itr_injury.Text;
								break;
							case "9":
								txt += "  x: " + itr_x.Text + "  y: " + itr_y.Text + "  w: " + itr_w.Text + "  h: " + itr_h.Text + "  dvx: " + itr_dvx.Text + (itr_arest.Text != "" ? "  arest: " + itr_arest.Text : "") + (itr_vrest.Text != "" ? "  vrest: " + itr_vrest.Text : "") + (itr_fall.Text != "" ? "  fall: " + itr_fall.Text : "") + "  injury: " + itr_injury.Text;
								break;
							default:
								if (itr_x.Text != "")
									txt += "  x: " + itr_x.Text;
								if (itr_y.Text != "")
									txt += "  y: " + itr_y.Text;
								if (itr_w.Text != "")
									txt += "  w: " + itr_w.Text;
								if (itr_h.Text != "")
									txt += "  h: " + itr_h.Text;
								if (itr_dvx.Text != "")
									txt += "  dvx: " + itr_dvx.Text;
								if (itr_dvy.Text != "")
									txt += "  dvy: " + itr_dvy.Text;
								if (itr_arest.Text != "")
									txt += "  arest: " + itr_arest.Text;
								if (itr_vrest.Text != "")
									txt += "  vrest: " + itr_vrest.Text;
								if (itr_fall.Text != "")
									txt += "  fall: " + itr_fall.Text;
								if (itr_bdefend.Text != "")
									txt += "  bdefend: " + itr_bdefend.Text;
								if (itr_injury.Text != "")
									txt += "  injury: " + itr_injury.Text;
								if (itr_zwidth.Text != "")
									txt += "  zwidth: " + itr_zwidth.Text;
								if (itr_effect.Text != "")
									txt += "\n      effect: " + itr_effect.Text;
								if (itr_catchingact.Text != "")
									txt += "  catchingact: " + itr_catchingact.Text;
								if (itr_caughtact.Text != "")
									txt += "  caughtact: " + itr_caughtact.Text;
								break;
						}
						txt += "\n   itr_end:";
						break;
					case 2:
						txt += "   wpoint:\n      kind: " + wpoint_kind.Text + "  x: " + wpoint_x.Text + "  y: " + wpoint_y.Text + "  weaponact: " + wpoint_weaponact.Text + "  attacking: " + wpoint_attacking.Text + "  cover: " + wpoint_cover.Text + "  dvx: " + wpoint_dvx.Text + "  dvy: " + wpoint_dvy.Text + "  dvz: " + wpoint_dvz.Text + "\n   wpoint_end:";
						break;
					case 3:
						txt += "   opoint:\n      kind: " + opoint_kind.Text + "  x: " + opoint_x.Text + "  y: " + opoint_y.Text + "  action: " + opoint_action.Text + "  dvx: " + opoint_dvx.Text + "  dvy: " + opoint_dvy.Text + "  oid: " + opoint_oid.Text + "  facing: " + opoint_facing.Text + "\n   opoint_end:";
						break;
					case 4:
						txt += "   cpoint:\n      kind: " + cpoint_kind.Text;
						if (cpoint_x.Text != "")
							txt += "  x: " + cpoint_x.Text;
						if (cpoint_y.Text != "")
							txt += "  y: " + cpoint_y.Text;
						if (cpoint_injury.Text != "")
							txt += "  injury: " + cpoint_injury.Text;
						if (cpoint_vaction.Text != "")
							txt += "  vaction: " + cpoint_vaction.Text;
						if (cpoint_aaction.Text != "")
							txt += "  aaction: " + cpoint_aaction.Text;
						if (cpoint_taction.Text != "")
							txt += "  taction: " + cpoint_taction.Text;
						if (cpoint_throwvx.Text != "")
							txt += "  throwvx: " + cpoint_throwvx.Text;
						if (cpoint_throwvy.Text != "")
							txt += "  throwvy: " + cpoint_throwvy.Text;
						if (cpoint_throwvz.Text != "")
							txt += "  throwvz: " + cpoint_throwvz.Text;
						if (cpoint_hurtable.Text != "")
							txt += "  hurtable: " + cpoint_hurtable.Text;
						if (cpoint_throwinjury.Text != "")
							txt += "  throwinjury: " + cpoint_throwinjury.Text;
						if (cpoint_decrease.Text != "")
							txt += "  decrease: " + cpoint_decrease.Text;
						if (cpoint_dircontrol.Text != "")
							txt += "  dircontrol: " + cpoint_dircontrol.Text;
						if (cpoint_cover.Text != "")
							txt += "  cover: " + cpoint_cover.Text;
						if (cpoint_fronthurtact.Text != "")
							txt += "  fronthurtact: " + cpoint_fronthurtact.Text;
						if (cpoint_backhurtact.Text != "")
							txt += "  backhurtact: " + cpoint_backhurtact.Text;
						txt += "\n   cpoint_end:";
						break;
					case 5:
						txt += "   bpoint:\n      x: " + bpoint_x.Text + "  y: " + bpoint_y.Text + "\n   bpoint_end:";
						break;
				}
			}
			catch (Exception ex)
			{
				mainForm.formEventLog.Error(ex, "ERROR");
			}
			if (txt != "")
			{
				if (richTextBox.Text == "")
					richTextBox.Text = txt;
				else
					richTextBox.AppendText("\n" + txt);

				richTextBox.SelectionStart = richTextBox.Text.Length;
				richTextBox.ScrollToCaret();
			}
		}

		void RichTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.V && e.Control)
			{
				(sender as RichTextBox).Paste(DataFormats.GetFormat(DataFormats.UnicodeText));
				e.Handled = true;
			}
		}

		void WeaponactChanged(object sender, EventArgs e)
		{
			drawBox.AutoRefresh = false;
			drawBox.PointImage = weaponactImage = (Image)Properties.Resources.ResourceManager.GetObject("weapon" + wpoint_weaponact.Text);
			if (drawBox.PointImage != null)
				drawBox.PointImageOffset = weaponPoints[wpoint_weaponact.SelectedIndex];
			else
				drawBox.PointImageOffset = Point.Empty;
			drawBox.AutoRefresh = true;
		}

		void NewLine(object sender, EventArgs e)
		{
			if (mainForm.ActiveDocument != null)
				mainForm.ActiveDocument.Scintilla.Selection.Text = (mainForm.ActiveDocument.Scintilla.EndOfLine.Mode == ScintillaNET.EndOfLineMode.LF ? "\n" : "\r\n");
		}

		void ImageIndexChanged(object sender, EventArgs e)
		{
			if (mainForm.lastActiveFrame != null)
				drawBox.Image = mainForm.lastActiveFrame[mainForm.lastActiveDoc.frameIndexTag = (int)numericUpDown_ImageIndex.Value];

			numericUpDown_ImageIndex.Refresh();
		}

		void CopyToClipboard(object sender, EventArgs e)
		{
			if (richTextBox.Text != "")
				Clipboard.SetText(richTextBox.Text);
		}

		void Clear(object sender, EventArgs e)
		{
			richTextBox.Text = "";
		}

		void TagChanged(object sender, EventArgs e)
		{
			drawBox.AutoRefresh = false;
			drawBox.Cover = false;
			drawBox.PointImage = null;
			drawBox.PointImageOffset = Point.Empty;
			switch (tabControl_Tags.SelectedIndex)
			{
				case 0:
					drawBox.RectangleColor = Color.Lime;
					drawBox.DrawingMode = DrawBox.DrawingMode.Rectangle;
					drawBox.DisplayMode = DrawBox.DisplayModes.Rectangle;
					drawBox.Cursor = cur_bdy;
					try
					{
						drawBox.Rectangle = new Rectangle(int.Parse(bdy_x.Text), int.Parse(bdy_y.Text), int.Parse(bdy_w.Text), int.Parse(bdy_h.Text));
					}
					catch { drawBox.Rectangle = Rectangle.Empty; }
					break;
				case 1:
					drawBox.RectangleColor = Color.Red;
					drawBox.VectorColor = Color.Red;
					drawBox.DrawingMode = DrawBox.DrawingMode.RectangleVector;
					drawBox.DisplayMode = DrawBox.DisplayModes.Rectangle | DrawBox.DisplayModes.Vector;
					drawBox.Cursor = cur_itr;
					try
					{
						drawBox.Rectangle = new Rectangle(int.Parse(itr_x.Text), int.Parse(itr_y.Text), int.Parse(itr_w.Text), int.Parse(itr_h.Text));
					}
					catch { drawBox.Rectangle = Rectangle.Empty; }
					try
					{
						drawBox.Vector = new Point(int.Parse(itr_dvx.Text), int.Parse(itr_dvy.Text));
					}
					catch { drawBox.Vector = Point.Empty; }
					break;
				case 2:
					drawBox.Cover = (wpoint_cover.Text != "0" && wpoint_cover.Text != "");
					drawBox.PointPenColor = Color.Blue;
					drawBox.VectorColor = Color.Blue;
					drawBox.DrawingMode = DrawBox.DrawingMode.PointVector;
					drawBox.DisplayMode = DrawBox.DisplayModes.Point | DrawBox.DisplayModes.Vector;
					drawBox.Cursor = cur_w;
					if (wpoint_weaponact.SelectedIndex >= 0)
					{
						drawBox.PointImage = weaponactImage;
						drawBox.PointImageOffset = weaponPoints[wpoint_weaponact.SelectedIndex];
					}
					try
					{
						drawBox.Point = new Point(int.Parse(wpoint_x.Text), int.Parse(wpoint_y.Text));
					}
					catch { drawBox.Point = Point.Empty; }
					try
					{
						drawBox.Vector = new Point(int.Parse(wpoint_dvx.Text), int.Parse(wpoint_dvy.Text));
					}
					catch { drawBox.Vector = Point.Empty; }
					break;
				case 3:
					drawBox.PointPenColor = Color.Purple;
					drawBox.VectorColor = Color.Purple;
					drawBox.DrawingMode = DrawBox.DrawingMode.PointVector;
					drawBox.DisplayMode = DrawBox.DisplayModes.Point | DrawBox.DisplayModes.Vector;
					drawBox.Cursor = cur_o;
					if (opoint_oid.SelectedIndex >= 0 && opoint_action.SelectedIndex >= 0)
					{
						drawBox.PointImage = opointImage;
						drawBox.PointImageOffset = opointOffset;
					}
					try
					{
						drawBox.Point = new Point(int.Parse(opoint_x.Text), int.Parse(opoint_y.Text));
					}
					catch { drawBox.Point = Point.Empty; }
					try
					{
						drawBox.Vector = new Point(int.Parse(opoint_dvx.Text), int.Parse(opoint_dvy.Text));
					}
					catch { drawBox.Vector = Point.Empty; }
					break;
				case 4:
					drawBox.Cover = (cpoint_cover.Text != "0" && cpoint_cover.Text != "");
					drawBox.PointPenColor = Color.OrangeRed;
					drawBox.VectorColor = Color.OrangeRed;
					drawBox.DrawingMode = DrawBox.DrawingMode.PointVector;
					drawBox.DisplayMode = DrawBox.DisplayModes.Point | DrawBox.DisplayModes.Vector;
					drawBox.Cursor = cur_c;
					if (vactionImage != null)
					{
						if (cpoint_dircontrol.Text == "0" || cpoint_dircontrol.Text == "")
						{
							drawBox.PointImage = vactionImageMirror;
							drawBox.PointImageOffset = new Point(drawBox.PointImage.Width - caughtPoints[cpoint_vaction.SelectedIndex, 2], caughtPoints[cpoint_vaction.SelectedIndex, 3]);
						}
						else
						{
							drawBox.PointImage = vactionImage;
							drawBox.PointImageOffset = new Point(caughtPoints[cpoint_vaction.SelectedIndex, 2], caughtPoints[cpoint_vaction.SelectedIndex, 3]);
						}
					}
					try
					{
						drawBox.Point = new Point(int.Parse(cpoint_x.Text), int.Parse(cpoint_y.Text));
					}
					catch { drawBox.Point = Point.Empty; }
					try
					{
						drawBox.Vector = new Point(int.Parse(cpoint_throwvx.Text), int.Parse(cpoint_throwvy.Text));
					}
					catch { drawBox.Vector = Point.Empty; }
					break;
				case 5:
					drawBox.PointPenColor = Color.Red;
					drawBox.DrawingMode = DrawBox.DrawingMode.Point;
					drawBox.DisplayMode = DrawBox.DisplayModes.Point;
					drawBox.PointImage = blood;
					drawBox.Cursor = cur_b;
					try
					{
						drawBox.Point = new Point(int.Parse(bpoint_x.Text), int.Parse(bpoint_y.Text));
					}
					catch { drawBox.Point = Point.Empty; }
					break;
			}
			drawBox.AutoRefresh = true;
		}

		void CoverChanged(object sender, EventArgs e)
		{
			switch (tabControl_Tags.SelectedIndex)
			{
				case 2:
					drawBox.Cover = (wpoint_cover.Text != "0" && wpoint_cover.Text != "");
					break;
				case 4:
					drawBox.Cover = (cpoint_cover.Text != "0" && cpoint_cover.Text != "");
					break;
			}
		}

		bool editing = false;

		void DrawBoxPointChanged(object sender, EventArgs e)
		{
			editing = true;
			switch (tabControl_Tags.SelectedIndex)
			{
				case 2:
					wpoint_x.Text = drawBox.Point.X.ToString();
					wpoint_y.Text = drawBox.Point.Y.ToString();
					wpoint_x.Refresh();
					wpoint_y.Refresh();
					break;
				case 3:
					opoint_x.Text = drawBox.Point.X.ToString();
					opoint_y.Text = drawBox.Point.Y.ToString();
					opoint_x.Refresh();
					opoint_y.Refresh();
					break;
				case 4:
					cpoint_x.Text = drawBox.Point.X.ToString();
					cpoint_y.Text = drawBox.Point.Y.ToString();
					cpoint_x.Refresh();
					cpoint_y.Refresh();
					break;
				case 5:
					bpoint_x.Text = drawBox.Point.X.ToString();
					bpoint_y.Text = drawBox.Point.Y.ToString();
					bpoint_x.Refresh();
					bpoint_y.Refresh();
					break;
			}
			editing = false;
		}

		void DrawBoxVectorChanged(object sender, EventArgs e)
		{
			editing = true;
			switch (tabControl_Tags.SelectedIndex)
			{
				case 1:
					itr_dvx.Text = drawBox.Vector.X.ToString();
					itr_dvy.Text = drawBox.Vector.Y.ToString();
					itr_dvx.Refresh();
					itr_dvy.Refresh();
					break;
				case 2:
					wpoint_dvx.Text = drawBox.Vector.X.ToString();
					wpoint_dvy.Text = drawBox.Vector.Y.ToString();
					wpoint_dvx.Refresh();
					wpoint_dvy.Refresh();
					break;
				case 3:
					opoint_dvx.Text = drawBox.Vector.X.ToString();
					opoint_dvy.Text = drawBox.Vector.Y.ToString();
					opoint_dvx.Refresh();
					opoint_dvy.Refresh();
					break;
				case 4:
					cpoint_throwvx.Text = drawBox.Vector.X.ToString();
					cpoint_throwvy.Text = drawBox.Vector.Y.ToString();
					cpoint_throwvx.Refresh();
					cpoint_throwvy.Refresh();
					break;
			}
			editing = false;
		}

		void DrawBoxRectangleChanged(object sender, EventArgs e)
		{
			if (drawBox.Rectangle.IsEmpty) return;

			editing = true;
			switch (tabControl_Tags.SelectedIndex)
			{
				case 0:
					bdy_x.Text = drawBox.Rectangle.X.ToString();
					bdy_y.Text = drawBox.Rectangle.Y.ToString();
					bdy_w.Text = drawBox.Rectangle.Width.ToString();
					bdy_h.Text = drawBox.Rectangle.Height.ToString();
					bdy_x.Refresh();
					bdy_y.Refresh();
					bdy_w.Refresh();
					bdy_h.Refresh();
					break;
				case 1:
					itr_x.Text = drawBox.Rectangle.X.ToString();
					itr_y.Text = drawBox.Rectangle.Y.ToString();
					itr_w.Text = drawBox.Rectangle.Width.ToString();
					itr_h.Text = drawBox.Rectangle.Height.ToString();
					itr_x.Refresh();
					itr_y.Refresh();
					itr_w.Refresh();
					itr_h.Refresh();
					break;
			}
			editing = false;
		}

		void BdyRectangleChanged(object sender, EventArgs e)
		{
			if (editing) return;
			try
			{
				drawBox.Rectangle = new Rectangle(int.Parse(bdy_x.Text), int.Parse(bdy_y.Text), int.Parse(bdy_w.Text), int.Parse(bdy_h.Text));
			}
			catch { }
		}

		void ItrRectangleChanged(object sender, EventArgs e)
		{
			if (editing) return;
			try
			{
				drawBox.Rectangle = new Rectangle(int.Parse(itr_x.Text), int.Parse(itr_y.Text), int.Parse(itr_w.Text), int.Parse(itr_h.Text));
			}
			catch { }
		}

		void ItrVectorChanged(object sender, EventArgs e)
		{
			if (editing) return;
			try
			{
				drawBox.Vector = new Point(int.Parse(itr_dvx.Text), int.Parse(itr_dvy.Text));
			}
			catch { }
		}

		void WpointPointChanged(object sender, EventArgs e)
		{
			if (editing) return;
			try
			{
				drawBox.Point = new Point(int.Parse(wpoint_x.Text), int.Parse(wpoint_y.Text));
			}
			catch { }
		}

		void WpointVectorChanged(object sender, EventArgs e)
		{
			if (editing) return;
			try
			{
				drawBox.Vector = new Point(int.Parse(wpoint_dvx.Text), int.Parse(wpoint_dvy.Text));
			}
			catch { }
		}

		void OpointPointChanged(object sender, EventArgs e)
		{
			if (editing) return;
			try
			{
				drawBox.Point = new Point(int.Parse(opoint_x.Text), int.Parse(opoint_y.Text));
			}
			catch { }
		}

		void OpointVectorChanged(object sender, EventArgs e)
		{
			if (editing) return;
			try
			{
				drawBox.Vector = new Point(int.Parse(opoint_dvx.Text), int.Parse(opoint_dvy.Text));
			}
			catch { }
		}

		void CpointPointChanged(object sender, EventArgs e)
		{
			if (editing) return;
			try
			{
				drawBox.Point = new Point(int.Parse(cpoint_x.Text), int.Parse(cpoint_y.Text));
			}
			catch { }
		}

		void CpointVectorChanged(object sender, EventArgs e)
		{
			if (editing) return;
			try
			{
				drawBox.Vector = new Point(int.Parse(cpoint_throwvx.Text), int.Parse(cpoint_throwvy.Text));
			}
			catch { }
		}

		void BpointChanged(object sender, EventArgs e)
		{
			if (editing) return;
			try
			{
				drawBox.Point = new Point(int.Parse(bpoint_x.Text), int.Parse(bpoint_y.Text));
			}
			catch { }
		}

		void VactionChanged(object sender, EventArgs e)
		{
			drawBox.AutoRefresh = false;
			bool dir = (cpoint_dircontrol.Text == "0" || cpoint_dircontrol.Text == "");
			vactionImageMirror = (Image)(vactionImage = (Image)Properties.Resources.ResourceManager.GetObject("caught" + caughtPoints[cpoint_vaction.SelectedIndex, 1])).Clone();
			if (vactionImage == null)
			{
				drawBox.PointImage = null;
				drawBox.PointImageOffset = Point.Empty;
				return;
			}
			vactionImageMirror.RotateFlip(RotateFlipType.RotateNoneFlipX);
			if (dir)
			{
				drawBox.PointImage = vactionImageMirror;
				drawBox.PointImageOffset = new Point(drawBox.PointImage.Width - caughtPoints[cpoint_vaction.SelectedIndex, 2], caughtPoints[cpoint_vaction.SelectedIndex, 3]);
			}
			else
			{
				drawBox.PointImage = vactionImage;
				drawBox.PointImageOffset = new Point(caughtPoints[cpoint_vaction.SelectedIndex, 2], caughtPoints[cpoint_vaction.SelectedIndex, 3]);
			}

			drawBox.AutoRefresh = true;
		}

		void DircontrolChanged(object sender, EventArgs e)
		{
			if (vactionImage == null) return;

			drawBox.AutoRefresh = false;

			if (cpoint_dircontrol.Text == "0" || cpoint_dircontrol.Text == "")
			{
				drawBox.PointImage = vactionImageMirror;
				drawBox.PointImageOffset = new Point(drawBox.PointImage.Width - caughtPoints[cpoint_vaction.SelectedIndex, 2], caughtPoints[cpoint_vaction.SelectedIndex, 3]);
			}
			else
			{
				drawBox.PointImage = vactionImage;
				drawBox.PointImageOffset = new Point(caughtPoints[cpoint_vaction.SelectedIndex, 2], caughtPoints[cpoint_vaction.SelectedIndex, 3]);
			}

			drawBox.AutoRefresh = true;
		}

		// TODO: Instead of adding image data to "opoint.cache", reference their file name and make them load itself with protobuf assigments

		public List<Obj> opointCache = new List<Obj>(64);

		[ProtoContract]
		public class Obj
		{
			[ProtoMember(1)]
			public int id;
			[ProtoMember(2)]
			public string file;
			[ProtoMember(4)]
			public List<Frame> frames;

			public Bitmap[] bmpList;

			[ProtoMember(3)]
			public byte[][] bmpLister
			{
				get
				{
					if (bmpList == null || bmpList.Length == 0)
						return null;
					byte[][] result = new byte[bmpList.Length][];
					using (MemoryStream ms = new MemoryStream())
					{
						for (int i = 0; i < bmpList.Length; i++)
						{
							if (bmpList[i] != null)
								bmpList[i].Save(ms, ImageFormat.Bmp);
							result[i] = ms.ToArray();
						}
					}
					return result;
				}
				set
				{
					if (value == null || value.Length == 0)
					{
						bmpList = new Bitmap[1];
						return;
					}
					bmpList = new Bitmap[value.Length];
					for (int i = 0; i < value.Length; i++)
						using (MemoryStream ms = new MemoryStream(value[i]))
							bmpList[i] = (Bitmap)Image.FromStream(ms);
				}
			}

			public Obj()
			{

			}

			public Obj(int id, string file, Bitmap[] bmpList, List<Frame> frames)
			{
				this.id = id;
				this.file = file;
				this.bmpList = bmpList;
				this.frames = frames;
			}
		}

		[ProtoContract]
		public class Frame
		{
			[ProtoMember(1)]
			public int id;
			[ProtoMember(2)]
			public int pic;
			public Point center;
			[ProtoMember(3)]
			public int centerX
			{
				get { return center.X; }
				set { center.X = value; }
			}
			[ProtoMember(4)]
			public int centerY
			{
				get { return center.Y; }
				set { center.Y = value; }
			}

			public Frame() { }

			public Frame(int id, int pic, Point center)
			{
				this.id = id;
				this.pic = pic;
				this.center = center;
			}

			public const string regexPattern = @".*pic: *(\d*).*centerx: *(\d*) *centery: *(\d*)";
		}

		public List<Frame> ParseFrames(string dat)
		{
			List<Frame> frames = new List<Frame>(400);
			List<string> frameStrList = new List<string>(400);
			for (int i = dat.IndexOf("<frame>"); i >= 0; i = dat.IndexOf("<frame>", i + 7))
			{
				if (backgroundWorker_CreateOpointCache.CancellationPending) return null;
				int j = dat.IndexOf("<frame_end>", i + 7);
				if (j < 0) return null;
				frameStrList.Add(dat.Substring(i + 7, j - i - 7));
			}
			for (int i = 0; i < frameStrList.Count; i++)
			{
				if (backgroundWorker_CreateOpointCache.CancellationPending) return frames;
				Match matchfx = Regex.Match(frameStrList[i], " *(\\d*)");
				Match match = Regex.Match(frameStrList[i], Frame.regexPattern);
				int pic, cx, cy, fx;
				int.TryParse(match.Groups[1].Value, out pic);
				int.TryParse(match.Groups[2].Value, out cx);
				int.TryParse(match.Groups[3].Value, out cy);
				int.TryParse(matchfx.Groups[1].Value, out fx);
				Frame frm = new Frame(fx, pic, new Point(cx, cy));
				frames.Add(frm);
			}
			return frames;
		}

		public List<FileMaker> ParseFiles(string lfDir, string dat)
		{
			List<FileMaker> fileList = new List<FileMaker>(8);
			int begin = dat.IndexOf("<bmp_begin>"), end = dat.IndexOf("<bmp_end>", begin + 11);
			if (begin < 0 || end < 0) return null;
			string script = dat.Substring(begin + 11, end - begin);
			MatchCollection matches = Regex.Matches(script, FileMaker.regexPattern);
			if (matches.Count < 1) return null;
			for (int i = 0; i < matches.Count; i++)
			{
				if (backgroundWorker_CreateOpointCache.CancellationPending) return fileList;
				string path = lfDir + "\\" + matches[i].Groups[3].Value.Trim();
				Bitmap img = (Bitmap)Image.FromFile(path);
				img.Tag = Path.GetFileName(path);
				int si = int.Parse(matches[i].Groups[1].Value),
					ei = int.Parse(matches[i].Groups[2].Value),
					w = int.Parse(matches[i].Groups[4].Value),
					h = int.Parse(matches[i].Groups[5].Value),
					r = int.Parse(matches[i].Groups[6].Value),
					c = int.Parse(matches[i].Groups[7].Value);
				FileMaker fm = new FileMaker(si, ei, img.Tag as string, img, w, h, c, r);
				fileList.Add(fm);
			}
			return fileList;
		}

		public Bitmap[] ParseBmpList(List<FileMaker> fileList)
		{
			int top = 1;
			foreach (FileMaker fm in fileList)
				if (fm.endIndex + 1 > top) top = fm.endIndex + 1;

			Bitmap[] frames = new Bitmap[top];
			for (int i = 0; i < top; i++)
				frames[i] = null;

			for (int i = 0; i < fileList.Count; i++)
			{
				FileMaker fm = fileList[i];
				int k = fm.startIndex;
				for (int r = 0; r < fm.row; r++)
				{
					for (int c = 0; c < fm.col && k <= fm.endIndex; c++, k++)
					{
						if (backgroundWorker_CreateOpointCache.CancellationPending) return frames;
						Bitmap btm = new Bitmap(fm.w, fm.h, PixelFormat.Format32bppRgb);
						using (Graphics g = Graphics.FromImage(btm))
							g.DrawImage(fm.image, new Rectangle(0, 0, fm.w, fm.h), new Rectangle(c * (fm.w + 1), r * (fm.h + 1), fm.w, fm.h), GraphicsUnit.Pixel);
						frames[k] = btm;
					}
				}
			}
			return frames;
		}

		void OpointCacheButtonClick(object sender, EventArgs e)
		{
			if (!backgroundWorker_CreateOpointCache.IsBusy)
			{
				opointCache.Clear();
				opoint_oid.Items.Clear();
				GC.Collect();
				if (!stopWatch.IsRunning)
					stopWatch.Start();
				button_CreateOpointCache.Text = "Cancel";
				backgroundWorker_CreateOpointCache.RunWorkerAsync();
			}
			else
				backgroundWorker_CreateOpointCache.CancelAsync();
		}

		void CreateOpointCache(object sender, DoWorkEventArgs e)
		{
			List<Obj> opointCache = new List<Obj>(128);
			string lfDir;
			string data_txt = (lfDir = Path.GetDirectoryName(Settings.Current.lfPath)) + "\\data\\data.txt";
			string data = File.ReadAllText(data_txt, Encoding.Default);
			int st = data.IndexOf("<object>"), end = data.IndexOf("<object_end>", st + 8);
			if (st < 0 || end < 0) return;
			data = data.Substring(st + 8, end - st);
			MatchCollection matches = Regex.Matches(data, @"id: *(\d*) *.*file: *(.*)", RegexOptions.IgnoreCase);
			for (int i = 0; i < matches.Count; i++)
			{
				if (backgroundWorker_CreateOpointCache.CancellationPending)
				{
					e.Cancel = true;
					return;
				}
				Match match = matches[i];
				int id;
				int.TryParse(match.Groups[1].Value.Trim(), out id);

				string file;
				int sh;
				if ((sh = (file = match.Groups[2].Value.Trim()).IndexOf('#')) >= 0)
					file = file.Substring(0, sh).Trim();

				backgroundWorker_CreateOpointCache.ReportProgress((int)(i / (float)(matches.Count) * 100), file);

				string dat = LF2DataUtil.Decrypt(lfDir + "\\" + file);
				List<FileMaker> fileList = ParseFiles(lfDir, dat);
				if (fileList == null) continue;
				Bitmap[] bmpList = ParseBmpList(fileList);
				List<Frame> frames = ParseFrames(dat);
				opointCache.Add(new Obj(id, file, bmpList, frames));
			}

			using (FileStream fs = new FileStream(opointCachePath, FileMode.Create))
				Serializer.Serialize<List<Obj>>(fs, opointCache);

			e.Result = opointCache;
		}

		void OpointCacheCreatorProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			label_CacheCreationProgress.Text = (string)e.UserState;
			progressBar_CacheCreation.Value = e.ProgressPercentage;
		}

		void OpointCacheCreatorRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				mainForm.formEventLog.Error(e.Error, "Opoint Cache Creator Error");
			}
			else if (!e.Cancelled && e.Result != null)
			{
				opointCache.AddRange(e.Result as List<Obj>);

				for (int i = 0; i < opointCache.Count; i++)
					opoint_oid.Items.Add(opointCache[i].id);

				progressBar_CacheCreation.Value = 100;
				label_CacheCreationProgress.Text = "data\\...";

				mainForm.formEventLog.Log("Cache Creation: " + stopWatch.Elapsed, true);
			}
			button_CreateOpointCache.Text = "Create Opoint Cache";
			stopWatch.Reset();
		}

		void OidChanged(object sender, EventArgs e)
		{
			int x = opoint_action.SelectedIndex, id = opoint_oid.SelectedIndex, pic;
			if (id < 0)
			{
				opoint_action.Items.Clear();
				return;
			}
			Obj o = opointCache[id];
			opoint_action.Items.Clear();
			for (int i = 0; i < o.frames.Count; i++)
				opoint_action.Items.Add(o.frames[i].id);
			drawBox.AutoRefresh = false;
			x = opoint_action.SelectedIndex = 0;
			pic = o.frames[x].pic;
			drawBox.PointImage = opointImage = ((pic != 999 && pic < o.bmpList.Length) ? o.bmpList[pic] : null);
			drawBox.PointImageOffset = opointOffset = o.frames[x].center;
			drawBox.AutoRefresh = true;
		}

		Image opointImage;
		Point opointOffset = Point.Empty;

		void Opoint_actionChanged(object sender, EventArgs e)
		{
			int x = opoint_action.SelectedIndex, id = opoint_oid.SelectedIndex, pic;
			if (id < 0)
			{
				opoint_action.Items.Clear();
				return;
			}
			if (x < 0) return;
			Obj o = opointCache[id];
			pic = o.frames[x].pic;
			drawBox.AutoRefresh = false;
			drawBox.PointImage = opointImage = ((pic != 999 && pic < o.bmpList.Length) ? o.bmpList[pic] : null);
			drawBox.PointImageOffset = opointOffset = o.frames[x].center;
			drawBox.AutoRefresh = true;
		}

		void RefreshViewerClick(object sender, EventArgs e)
		{
			if (!backgroundWorker_Refresh.IsBusy)
			{
				opointCache.Clear();
				GC.Collect();
				if (!stopWatch.IsRunning)
					stopWatch.Start();
				button_RefreshOpointViewer.Text = "...";
				backgroundWorker_Refresh.RunWorkerAsync();
			}
		}

		void CacheDeseralizerDoWork(object sender, DoWorkEventArgs e)
		{
			string cachePath = opointCachePath;
			if (File.Exists(cachePath))
			{
				List<Obj> opointCache;
				using (FileStream fs = new FileStream(cachePath, FileMode.Open))
					opointCache = (List<Obj>)Serializer.Deserialize<List<Obj>>(fs);
				e.Result = opointCache;
			}
		}

		void CacheDeseralizerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				mainForm.formEventLog.Error(e.Error, "Opoint Cache Deserialization Error");
			}
			else if (e.Result != null)
			{
				opointCache.Clear();
				opointCache.AddRange(e.Result as List<Obj>);

				opoint_oid.Items.Clear();
				foreach (Obj obj in opointCache)
					opoint_oid.Items.Add(obj.id);

				mainForm.formEventLog.Log("Cache Deserialization: " + stopWatch.Elapsed, true);
			}
			button_RefreshOpointViewer.Text = "Refresh";
			stopWatch.Reset();
		}
	}
}
