﻿#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

#endregion

namespace DrawBox
{
	#region Enums

	public enum DrawingMode
	{
		None,
		Point,
		Vector,
		Rectangle,
		Zwidth,
		Center,
		RectangleVector,
		PointVector,
		Table
	}

	[Flags]
	public enum DisplayModes
	{
		None = 0,
		Point = 1,
		Vector = 2,
		Rectangle = 4,
		Zwidth = 8,
		Center = 16,
		Table = 32,
		All = 63
	}

	public enum PictureMode
	{
		Normal,
		CenterImage,
		CenterOrigin,
		Stretch,
		Zoom,
		FillZoom,
		ShrinkOnly,
		GrowOnly,
		Tile,
		AutoSize
	}

	#endregion

	public class DrawBox : Control
	{
		#region Constructors

		public DrawBox()
			: base()
		{
			imageAttr.SetColorKey(trancparencyKey, trancparencyKey);
			this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
			this.TabStop = false;
		}

		#endregion

		#region Fields

		private ToolTip toolTipC = new ToolTip();
		private ToolTip toolTipB = new ToolTip();
		private ToolTip toolTipBB = new ToolTip();

		private static readonly Point[] pointer = { new Point(-8, 0), new Point(-1, 0), new Point(0, -8), new Point(0, -1), new Point(1, 0), new Point(8, 0), new Point(0, 1), new Point(0, 8), new Point(-5, -5), new Point(-2, -2), new Point(2, -2), new Point(5, -5), new Point(2, 2), new Point(5, 5), new Point(-2, 2), new Point(-5, 5) };
		private static readonly Point[] arrow = { new Point(0, -5), new Point(-7, 15), new Point(0, 5), new Point(7, 15) };

		private readonly ImageAttributes imageAttr = new ImageAttributes();

		bool autoRefresh = true;
		[DefaultValue(true)]
		public bool AutoRefresh
		{
			get { return autoRefresh; }
			set { autoRefresh = value; if (autoRefresh) this.Refresh(); }
		}

		int vectorDivision = 1;
		[DefaultValue(1)]
		public int VectorDivision
		{
			get { return vectorDivision; }
			set { vectorDivision = value; }
		}

		bool trancparency;
		[DefaultValue(false)]
		public bool Trancparency
		{
			get { return trancparency; }
			set
			{
				bool old = trancparency;
				trancparency = value;
				if (autoRefresh) this.Refresh();

				if (old != value && TrancparencyChanged != null)
				{
					TrancparencyChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler TrancparencyChanged;

		Color trancparencyKey = Color.Black;
		[DefaultValue(typeof(Color), "Black")]
		public Color TrancparencyKey
		{
			get { return trancparencyKey; }
			set
			{
				Color old = trancparencyKey;
				trancparencyKey = value;
				imageAttr.SetColorKey(trancparencyKey, trancparencyKey);
				if (autoRefresh) this.Refresh();

				if (old != value && TrancparencyKeyChanged != null)
				{
					TrancparencyKeyChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler TrancparencyKeyChanged;

		DrawingMode drawingMode;
		[DefaultValue(DrawingMode.None)]
		public DrawingMode DrawingMode
		{
			get { return drawingMode; }
			set
			{
				DrawingMode old = drawingMode;
				drawingMode = value;
				if (autoRefresh) this.Refresh();

				if (old != value && DrawingModeChanged != null)
				{
					DrawingModeChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler DrawingModeChanged;

		DisplayModes displayMode;
		[DefaultValue(DisplayModes.None)]
		public DisplayModes DisplayMode
		{
			get { return displayMode; }
			set
			{
				DisplayModes old = displayMode;
				displayMode = value;
				if (autoRefresh) this.Refresh();

				if (old != value && DisplayModeChanged != null)
				{
					DisplayModeChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler DisplayModeChanged;

		PictureMode pictureMode;
		[DefaultValue(PictureMode.Normal)]
		public PictureMode PictureMode
		{
			get { return pictureMode; }
			set
			{
				PictureMode old = pictureMode;
				pictureMode = value;

				if (pictureMode == PictureMode.AutoSize && image != null)
					this.Size = image.Size;

				if (autoRefresh) this.Refresh();

				if (old != value && PictureModeChanged != null)
				{
					PictureModeChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler PictureModeChanged;

		InterpolationMode interpolation;
		[DefaultValue(InterpolationMode.Default)]
		public InterpolationMode Interpolation
		{
			get { return interpolation; }
			set
			{
				InterpolationMode old = interpolation;
				interpolation = value;
				if (autoRefresh) this.Refresh();

				if (old != value && InterpolationChanged != null)
				{
					InterpolationChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler InterpolationChanged;

		InterpolationMode backgroundInterpolation;
		[DefaultValue(InterpolationMode.Default)]
		public InterpolationMode BackgroundInterpolation
		{
			get { return backgroundInterpolation; }
			set
			{
				InterpolationMode old = backgroundInterpolation;
				backgroundInterpolation = value;
				if (autoRefresh) this.Refresh();

				if (old != value && BackgroundInterpolationChanged != null)
				{
					BackgroundInterpolationChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler BackgroundInterpolationChanged;

		SmoothingMode smoothing;
		[DefaultValue(SmoothingMode.Default)]
		public SmoothingMode Smoothing
		{
			get { return smoothing; }
			set
			{
				SmoothingMode old = smoothing;
				smoothing = value;
				if (autoRefresh) this.Refresh();

				if (old != value && SmoothingChanged != null)
				{
					SmoothingChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler SmoothingChanged;

		int imageIndent = 0;
		[DefaultValue(0)]
		public int ImageIndent
		{
			get { return imageIndent; }
			set
			{
				int old = imageIndent;
				imageIndent = value;
				if (autoRefresh) this.Refresh();

				if (old != value && ImageIntendChanged != null)
				{
					ImageIntendChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler ImageIntendChanged;

		public Rectangle Matrix
		{
			get
			{
				Size img = image != null ? new Size(image.Width, image.Height) : Size.Empty;
				Rectangle corigin = new Rectangle(this.Width / 2, this.Height / 2, img.Width, img.Height);
				Rectangle zoomed = ExpandToBound(img, this.Size, false);
				Rectangle filled = ExpandToBound(img, this.Size, true);
				Rectangle cimage = new Rectangle((this.Width - img.Width) / 2, (this.Height - img.Height) / 2, img.Width, img.Height);

				switch (pictureMode)
				{
					case PictureMode.CenterImage:
						return cimage;
					case PictureMode.CenterOrigin:
						return corigin;
					case PictureMode.Stretch:
						return new Rectangle(0, 0, this.Width, this.Height);
					case PictureMode.Zoom:
						return zoomed;
					case PictureMode.FillZoom:
						return filled;
					case PictureMode.ShrinkOnly:
						return (img.Width > this.Width || img.Height > this.Height) ? zoomed : cimage;
					case PictureMode.GrowOnly:
						return (img.Width < this.Width && img.Height < this.Height) ? zoomed : cimage;
					default:
						return new Rectangle(Point.Empty, img);
				}
			}
		}

		Point point;
		[DefaultValue(typeof(Point), "0, 0")]
		public Point Point
		{
			get { return point; }
			set
			{
				Point old = point;
				point = value;
				if (autoRefresh) this.Refresh();

				if (old != value && PointChanged != null)
				{
					PointChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler PointChanged;

		Point vector;
		[DefaultValue(typeof(Point), "0, 0")]
		public Point Vector
		{
			get { return vector; }
			set
			{
				Point old = vector;
				vector = value;
				if (autoRefresh) this.Refresh();

				if (old != value && VectorChanged != null)
				{
					VectorChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler VectorChanged;

		Rectangle rectangle;
		[DefaultValue(typeof(Rectangle), "-1, -1, 0, 0")]
		public Rectangle Rectangle
		{
			get { return new Rectangle(rectangle.Width < 0 ? rectangle.X + rectangle.Width : rectangle.X, rectangle.Height < 0 ? rectangle.Y + rectangle.Height : rectangle.Y, Math.Abs(rectangle.Width), Math.Abs(rectangle.Height)); }
			set
			{
				Rectangle old = rectangle;
				rectangle = value;
				if (autoRefresh) this.Refresh();

				if (old != value && RectangleChanged != null)
				{
					RectangleChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler RectangleChanged;

		int zwidth;
		[DefaultValue(0)]
		public int Zwidth
		{
			get { return zwidth; }
			set
			{
				int old = zwidth;
				zwidth = value;
				if (autoRefresh) this.Refresh();

				if (old != value && ZwidthChanged != null)
				{
					ZwidthChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler ZwidthChanged;

		Point table;
		[DefaultValue(typeof(Point), "0, 0")]
		public Point Table
		{
			get { return table; }
			set
			{
				Point old = table;
				table = value;
				if (autoRefresh) this.Refresh();

				if (old != value && TableChanged != null)
				{
					TableChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler TableChanged;

		Point center;
		[DefaultValue(typeof(Point), "0, 0")]
		public Point Center
		{
			get { return center; }
			set
			{
				Point old = center;
				center = value;
				if (autoRefresh) this.Refresh();

				if (old != value && CenterChanged != null)
				{
					CenterChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler CenterChanged;

		Pen pointPen = new Pen(Color.Blue, 1.75f);
		[Browsable(false)]
		public Pen PointPen
		{
			get { return pointPen; }
			set
			{
				Pen old = pointPen;
				pointPen = value;
				if (autoRefresh) this.Refresh();

				if (old != value && PointPenChanged != null)
				{
					PointPenChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler PointPenChanged;

		[DefaultValue(typeof(Color), "Blue")]
		public Color PointPenColor
		{
			get { return pointPen.Color; }
			set
			{
				Color old = pointPen.Color;
				pointPen.Color = value;
				if (autoRefresh) this.Refresh();

				if (old != value && PointPenChanged != null)
				{
					PointPenChanged(this, EventArgs.Empty);
				}
			}
		}

		Image pointImage = null;
		[DefaultValue(null)]
		public Image PointImage
		{
			get { return pointImage; }
			set
			{
				Image old = pointImage;
				pointImage = value;
				if (autoRefresh) this.Refresh();

				if (!Object.ReferenceEquals(old, value) && PointImageChanged != null)
				{
					PointImageChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler PointImageChanged;

		bool cover;
		[DefaultValue(false)]
		public bool Cover
		{
			get { return cover; }
			set
			{
				bool old = cover;
				cover = value;
				if (autoRefresh) this.Refresh();

				if (old != value && CoverChanged != null)
				{
					CoverChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler CoverChanged;

		Point pointImageOffset;
		[DefaultValue(typeof(Point), "0, 0")]
		public Point PointImageOffset
		{
			get { return pointImageOffset; }
			set
			{
				Point old = pointImageOffset;
				pointImageOffset = value;
				if (autoRefresh) this.Refresh();

				if (old != value && PointImageOffsetChanged != null)
				{
					PointImageOffsetChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler PointImageOffsetChanged;

		SolidBrush vectorBrush = new SolidBrush(Color.Blue);
		[Browsable(false)]
		public SolidBrush VectorBrush
		{
			get { return vectorBrush; }
			set
			{
				SolidBrush old = vectorBrush;
				vectorBrush = value;
				if (autoRefresh) this.Refresh();

				if (old != value && VectorBrushChanged != null)
				{
					VectorBrushChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler VectorBrushChanged;

		[DefaultValue(typeof(Color), "Blue")]
		public Color VectorBrushColor
		{
			get { return vectorBrush.Color; }
			set
			{
				Color old = vectorBrush.Color;
				vectorBrush.Color = value;
				if (autoRefresh) this.Refresh();

				if (old != value && VectorBrushChanged != null)
				{
					VectorBrushChanged(this, EventArgs.Empty);
				}
			}
		}

		Pen vectorPen = new Pen(Color.Blue, 2f);
		[Browsable(false)]
		public Pen VectorPen
		{
			get { return vectorPen; }
			set
			{
				Pen old = vectorPen;
				vectorPen = value;
				if (autoRefresh) this.Refresh();

				if (old != value && VectorPenChanged != null)
				{
					VectorPenChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler VectorPenChanged;

		[DefaultValue(typeof(Color), "Blue")]
		public Color VectorPenColor
		{
			get { return vectorPen.Color; }
			set
			{
				Color old = vectorPen.Color;
				vectorPen.Color = value;
				if (autoRefresh) this.Refresh();

				if (old != value && VectorPenChanged != null)
				{
					VectorPenChanged(this, EventArgs.Empty);
				}
			}
		}

		public Color VectorColor
		{
			set { vectorBrush.Color = vectorPen.Color = value; }
		}

		Pen rectanglePen = new Pen(Color.Blue);
		[Browsable(false)]
		public Pen RectanglePen
		{
			get { return rectanglePen; }
			set
			{
				Pen old = rectanglePen;
				rectanglePen = value;
				if (autoRefresh) this.Refresh();

				if (old != value && RectanglePenChanged != null)
				{
					RectanglePenChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler RectanglePenChanged;

		[DefaultValue(typeof(Color), "Blue")]
		public Color RectanglePenColor
		{
			get { return rectanglePen.Color; }
			set
			{
				Color old = rectanglePen.Color;
				rectanglePen.Color = value;
				if (autoRefresh) this.Refresh();

				if (old != value && RectanglePenChanged != null)
				{
					RectanglePenChanged(this, EventArgs.Empty);
				}
			}
		}

		SolidBrush rectangleBrush = new SolidBrush(Color.FromArgb(64, 0, 0, 255));
		[Browsable(false)]
		public SolidBrush RectangleBrush
		{
			get { return rectangleBrush; }
			set
			{
				SolidBrush old = rectangleBrush;
				rectangleBrush = value;
				if (autoRefresh) this.Refresh();

				if (old != value && RectangleBrushChanged != null)
				{
					RectangleBrushChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler RectangleBrushChanged;

		[DefaultValue(typeof(Color), "64, 0, 0, 255")]
		public Color RectangleBrushColor
		{
			get { return rectangleBrush.Color; }
			set
			{
				Color old = rectangleBrush.Color;
				rectangleBrush.Color = value;
				if (autoRefresh) this.Refresh();

				if (old != value && RectangleBrushChanged != null)
				{
					RectangleBrushChanged(this, EventArgs.Empty);
				}
			}
		}

		[DefaultValue(typeof(Color), "Blue")]
		public Color RectangleColor
		{
			set
			{
				rectangleBrush.Color = Color.FromArgb(rectangleBrush.Color.A, rectanglePen.Color = value);

				if (RectangleColorSet != null)
				{
					RectangleColorSet(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler RectangleColorSet;

		Pen zwidthPen = new Pen(Color.Blue);
		[Browsable(false)]
		public Pen ZwidthPen
		{
			get { return zwidthPen; }
			set
			{
				Pen old = zwidthPen;
				zwidthPen = value;
				if (autoRefresh) this.Refresh();

				if (old != value && ZwidthPenChanged != null)
				{
					ZwidthPenChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler ZwidthPenChanged;

		[DefaultValue(typeof(Color), "Blue")]
		public Color ZwidthPenColor
		{
			get { return zwidthPen.Color; }
			set
			{
				Color old = zwidthPen.Color;
				zwidthPen.Color = value;
				if (autoRefresh) this.Refresh();

				if (old != value && ZwidthPenChanged != null)
				{
					ZwidthPenChanged(this, EventArgs.Empty);
				}
			}
		}

		SolidBrush centerBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
		[Browsable(false)]
		public SolidBrush CenterBrush
		{
			get { return centerBrush; }
			set
			{
				SolidBrush old = centerBrush;
				centerBrush = value;
				if (autoRefresh) this.Refresh();

				if (old != value && CenterBrushChanged != null)
				{
					CenterBrushChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler CenterBrushChanged;

		[DefaultValue(typeof(Color), "128, 0, 0, 0")]
		public Color CenterBrushColor
		{
			get { return centerBrush.Color; }
			set
			{
				Color old = centerBrush.Color;
				centerBrush.Color = value;
				if (autoRefresh) this.Refresh();

				if (old != value && CenterBrushChanged != null)
				{
					CenterBrushChanged(this, EventArgs.Empty);
				}
			}
		}

		Pen tablePen = new Pen(Color.Lime);
		[Browsable(false)]
		public Pen TablePen
		{
			get { return tablePen; }
			set
			{
				Pen old = tablePen;
				tablePen = value;
				if (autoRefresh) this.Refresh();

				if (old != value && TablePenChanged != null)
				{
					TablePenChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler TablePenChanged;

		[DefaultValue(typeof(Color), "Lime")]
		public Color TablePenColor
		{
			get { return tablePen.Color; }
			set
			{
				Color old = tablePen.Color;
				tablePen.Color = value;
				if (autoRefresh) this.Refresh();

				if (old != value && TablePenChanged != null)
				{
					TablePenChanged(this, EventArgs.Empty);
				}
			}
		}

		Pen coordinatePen = new Pen(Color.Red);
		[Browsable(false)]
		public Pen CoordinatePen
		{
			get { return coordinatePen; }
			set
			{
				Pen old = coordinatePen;
				coordinatePen = value;
				if (autoRefresh) this.Refresh();

				if (old != value && CoordinatePenChanged != null)
				{
					CoordinatePenChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler CoordinatePenChanged;

		[DefaultValue(typeof(Color), "Red")]
		public Color CoordinatePenColor
		{
			get { return coordinatePen.Color; }
			set
			{
				Color old = coordinatePen.Color;
				coordinatePen.Color = value;
				if (autoRefresh) this.Refresh();

				if (old != value && CoordinatePenChanged != null)
				{
					CoordinatePenChanged(this, EventArgs.Empty);
				}
			}
		}

		Image image;
		[DefaultValue(null)]
		public Image Image
		{
			get { return image; }
			set
			{
				Image old = image;
				image = value;
				if (pictureMode == PictureMode.AutoSize)
					this.Size = image.Size;
				if (autoRefresh) this.Refresh();

				if (!Object.ReferenceEquals(old, value) && ImageChanged != null)
				{
					ImageChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler ImageChanged;

		bool showCoordinateSystem;
		[DefaultValue(false)]
		public bool ShowCoordinateSystem
		{
			get { return showCoordinateSystem; }
			set
			{
				bool old = showCoordinateSystem;
				showCoordinateSystem = value;
				if (autoRefresh) this.Refresh();

				if (old != value && ShowCoordinateSystemChanged != null)
				{
					ShowCoordinateSystemChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler ShowCoordinateSystemChanged;

		bool showCoordinateToolTip;
		[DefaultValue(false)]
		public bool ShowCoordinateToolTip
		{
			get { return showCoordinateToolTip; }
			set
			{
				bool old = showCoordinateToolTip;
				showCoordinateToolTip = value;
				if (autoRefresh) this.Refresh();

				if (old != value && ShowCoordinateToolTipChanged != null)
				{
					ShowCoordinateToolTipChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler ShowCoordinateToolTipChanged;

		bool showBoundToolTip;
		[DefaultValue(false)]
		public bool ShowBoundToolTip
		{
			get { return showBoundToolTip; }
			set
			{
				bool old = showBoundToolTip;
				showBoundToolTip = value;
				if (autoRefresh) this.Refresh();

				if (old != value && ShowBoundToolTipChanged != null)
				{
					ShowBoundToolTipChanged(this, EventArgs.Empty);
				}
			}
		}
		public event EventHandler ShowBoundToolTipChanged;

		#endregion

		#region Methods

		//public DrawBox Clone() { return (DrawBox)MemberwiseClone(); }

		private bool HasFlag(DisplayModes mode, DisplayModes flag) { return (mode & flag) != 0; }

		public static Rectangle ExpandToBound(Size size, Size box, bool fill)
		{
			double widthScale = 0, heightScale = 0;

			if (size.Width != 0)
				widthScale = (double)box.Width / (double)size.Width;
			if (size.Height != 0)
				heightScale = (double)box.Height / (double)size.Height;

			double scale = fill ? Math.Max(widthScale, heightScale) : Math.Min(widthScale, heightScale);

			Size result = new Size((int)(size.Width * scale), (int)(size.Height * scale));
			return new Rectangle(new Point((box.Width - result.Width) / 2, (box.Height - result.Height) / 2), result);
		}

		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			if (pictureMode == PictureMode.AutoSize && image != null && this.Dock == DockStyle.None)
			{
				base.SetBoundsCore(x, y, image.Width + imageIndent, image.Height + imageIndent, specified);
				if (autoRefresh) this.Refresh();
			}
			else
			{
				base.SetBoundsCore(x, y, width, height, specified);
				if (autoRefresh) this.Refresh();
			}
		}

		public static double Radian2Degree(double a)
		{
			return a / Math.PI * 180.0;
		}

		#endregion

		#region Painting

		[EditorBrowsable]
		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = interpolation;
			e.Graphics.SmoothingMode = smoothing;

			Rectangle matrix = Matrix, dest = new Rectangle(imageIndent, imageIndent, matrix.Width, matrix.Height);
			e.Graphics.TranslateTransform(matrix.X, matrix.Y);

			if (HasFlag(displayMode, DisplayModes.Center) && trancparency)
				e.Graphics.FillEllipse(centerBrush, center.X - 17, center.Y - 4, 35, 7);

			if (HasFlag(displayMode, DisplayModes.Point) && pointImage != null && cover)
			{
				Point p = point;
				p.Offset(-pointImageOffset.X, -pointImageOffset.Y);
				e.Graphics.DrawImage(pointImage, new Rectangle(p, pointImage.Size), 0, 0, pointImage.Width, pointImage.Height, GraphicsUnit.Pixel, imageAttr);
			}

			if (image != null)
			{
				switch (pictureMode)
				{
					case PictureMode.Tile:
						if (trancparency)
							using (Bitmap tex = new Bitmap(image.Width, image.Height))
							{
								using (Graphics g = Graphics.FromImage(tex))
									g.DrawImage(image, new Rectangle(0, 0, tex.Width, tex.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttr);
								using (TextureBrush b = new TextureBrush(tex))
								{
									e.Graphics.TranslateTransform(imageIndent, imageIndent);
									e.Graphics.FillRectangle(b, 0, 0, this.Width - imageIndent, this.Height - imageIndent);
									e.Graphics.TranslateTransform(-imageIndent, -imageIndent);
								}
							}
						else
							using (TextureBrush b = new TextureBrush(image))
							{
								e.Graphics.TranslateTransform(imageIndent, imageIndent);
								e.Graphics.FillRectangle(b, 0, 0, this.Width, this.Height);
								e.Graphics.TranslateTransform(-imageIndent, -imageIndent);
							}
						break;
					default:
						if (trancparency)
							e.Graphics.DrawImage(image, dest, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttr);
						else
							e.Graphics.DrawImage(image, dest);
						break;
				}
			}

			if (showCoordinateSystem)
			{
				e.Graphics.DrawLine(coordinatePen, -this.Width, 0, this.Width, 0);
				e.Graphics.DrawLine(coordinatePen, 0, -this.Height, 0, this.Height);
			}

			if (HasFlag(displayMode, DisplayModes.Point) && pointImage == null)
			{
				e.Graphics.TranslateTransform(point.X, point.Y);
				for (int i = 0; i < pointer.Length; i += 2)
					e.Graphics.DrawLine(pointPen, pointer[i], pointer[i + 1]);
				e.Graphics.TranslateTransform(-point.X, -point.Y);
			}

			if (HasFlag(displayMode, DisplayModes.Point) && pointImage != null && !cover)
			{
				Point p = point;
				p.Offset(-pointImageOffset.X, -pointImageOffset.Y);
				e.Graphics.DrawImage(pointImage, new Rectangle(p, pointImage.Size), 0, 0, pointImage.Width, pointImage.Height, GraphicsUnit.Pixel, imageAttr);
			}

			if (HasFlag(displayMode, DisplayModes.Rectangle))
			{
				Rectangle rec = this.Rectangle;
				e.Graphics.DrawRectangle(rectanglePen, rec);
				e.Graphics.FillRectangle(rectangleBrush, rec);
			}

			if (HasFlag(displayMode, DisplayModes.Vector) && (vector.X != 0 || vector.Y != 0))
			{
				Matrix mx = e.Graphics.Transform.Clone();
				if (DrawingMode == DrawingMode.PointVector)
					e.Graphics.TranslateTransform(point.X, point.Y);
				else if (DrawingMode == DrawingMode.RectangleVector)
					e.Graphics.TranslateTransform(rectangle.X + rectangle.Width / 2, rectangle.Y + rectangle.Height / 2);
				else
					e.Graphics.TranslateTransform(matrix.Width / 2 + imageIndent, matrix.Height / 2 + imageIndent);
				e.Graphics.DrawLine(vectorPen, 0, 0, vector.X, vector.Y);
				e.Graphics.TranslateTransform(vector.X, vector.Y);
				float f = (float)(Radian2Degree(Math.Atan((vector.Y) / (double)(vector.X))) + ((vector.X) < 0 ? -90 : 90));
				e.Graphics.RotateTransform(f);
				e.Graphics.FillPolygon(vectorBrush, arrow);
				e.Graphics.Transform = mx;
			}

			if (HasFlag(displayMode, DisplayModes.Zwidth) && image != null)
			{
				e.Graphics.DrawLine(zwidthPen, imageIndent, imageIndent - zwidth - 1, imageIndent + matrix.Width - 1, imageIndent - zwidth - 1);
				e.Graphics.DrawLine(zwidthPen, imageIndent, imageIndent + matrix.Height + zwidth, imageIndent + matrix.Width - 1, imageIndent + matrix.Height + zwidth);
			}

			if (HasFlag(displayMode, DisplayModes.Center) && !trancparency)
				e.Graphics.FillEllipse(centerBrush, center.X - 17, center.Y - 4, 35, 7);

			if (HasFlag(displayMode, DisplayModes.Table) && table.X > 0 && table.Y > 0)
			{
				for (int i = table.X - 1; i <= matrix.Width + imageIndent; i += table.X)
					e.Graphics.DrawLine(tablePen, i, 0, i, matrix.Height + imageIndent);
				for (int j = table.Y - 1; j <= matrix.Height + imageIndent; j += table.Y)
					e.Graphics.DrawLine(tablePen, 0, j, matrix.Width + imageIndent, j);
			}
		}

		[EditorBrowsable]
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = backgroundInterpolation;
			base.OnPaintBackground(e);
		}

		#endregion

		#region Mouse Handlers

		private bool leftMouse, rightMouse, middleMouse;
		[Browsable(false)]
		public bool LeftMouse { get { return leftMouse; } }
		[Browsable(false)]
		public bool RightMouse { get { return rightMouse; } }
		[Browsable(false)]
		public bool MiddleMouse { get { return middleMouse; } }
		[Browsable(false)]
		public bool LeftOrRightMouse { get { return leftMouse | rightMouse; } }
		[Browsable(false)]
		public bool LeftAndRightMouse { get { return leftMouse & rightMouse; } }
		[Browsable(false)]
		public bool AnyMouse { get { return leftMouse | rightMouse | middleMouse; } }

		object lastBounds = new object(), lastBBounds = new object();
		bool b, bb;

		Point relativeMouseLocation = Point.Empty,
				controlMouseLocationC = Point.Empty,
				controlMouseLocationB = Point.Empty,
				controlMouseLocationBB = Point.Empty,
				mouse = Point.Empty;

		[EditorBrowsable]
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if ((e.Button & MouseButtons.Left) != 0)
				leftMouse = true;
			if ((e.Button & MouseButtons.Right) != 0)
				rightMouse = true;
			if ((e.Button & MouseButtons.Middle) != 0)
				middleMouse = true;

			Rectangle matrix = Matrix;
			relativeMouseLocation = controlMouseLocationB = controlMouseLocationBB = e.Location;
			controlMouseLocationB.Offset(15, -25);
			controlMouseLocationBB.Offset(15, -5);
			relativeMouseLocation.Offset(-matrix.X, -matrix.Y);

			switch (drawingMode)
			{
				case DrawingMode.Point:
					if (LeftOrRightMouse)
					{
						Point = new Point(e.X - matrix.X, e.Y - matrix.Y);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = point).ToString(), this, controlMouseLocationB);
						b = true;
					}
					break;
				case DrawingMode.Vector:
					if (LeftOrRightMouse)
					{
						Vector = new Point((e.X - matrix.X - matrix.Width / 2 - imageIndent) / vectorDivision, (e.Y - matrix.Y - matrix.Height / 2 - imageIndent) / vectorDivision);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = vector).ToString(), this, controlMouseLocationB);
						b = true;
					}
					break;
				case DrawingMode.Rectangle:
					if (LeftOrRightMouse && e.Location != rectangle.Location)
					{
						Rectangle = new Rectangle(e.X - matrix.X, e.Y - matrix.Y, rectangle.Width, rectangle.Height);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = Rectangle).ToString(), this, controlMouseLocationB);
						b = true;
					}
					break;
				case DrawingMode.Zwidth:
					if (LeftOrRightMouse)
					{
						Zwidth = Math.Abs(e.Y - matrix.Y);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = zwidth).ToString(), this, controlMouseLocationB);
						b = true;
					}
					break;
				case DrawingMode.Center:
					if (LeftOrRightMouse)
					{
						Center = new Point(e.X - matrix.X, e.Y - matrix.Y);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = center).ToString(), this, controlMouseLocationB);
						b = true;
					}
					break;
				case DrawingMode.RectangleVector:
					if (LeftMouse)
					{
						if (e.Location != rectangle.Location)
							Rectangle = new Rectangle(e.X - matrix.X, e.Y - matrix.Y, rectangle.Width, rectangle.Height);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = Rectangle).ToString(), this, controlMouseLocationB);
						b = true;
					}
					if (RightMouse)
					{
						Vector = new Point((e.X - matrix.X - rectangle.X - rectangle.Width / 2) / vectorDivision, (e.Y - matrix.Y - rectangle.Y - rectangle.Height / 2) / vectorDivision);
						if (showBoundToolTip)
							toolTipBB.Show((lastBBounds = vector).ToString(), this, controlMouseLocationBB);
						bb = true;
					}
					break;
				case DrawingMode.PointVector:
					if (LeftMouse)
					{
						Point = new Point(e.X - matrix.X, e.Y - matrix.Y);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = point).ToString(), this, controlMouseLocationB);
						b = true;
					}
					if (RightMouse)
					{
						Vector = new Point((e.X - matrix.X - point.X) / vectorDivision, (e.Y - matrix.Y - point.Y) / vectorDivision);
						if (showBoundToolTip)
							toolTipBB.Show((lastBBounds = vector).ToString(), this, controlMouseLocationBB);
						bb = true;
					}
					break;
				case DrawingMode.Table:
					if (LeftOrRightMouse)
					{
						Table = new Point(e.X - matrix.X, e.Y - matrix.Y);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = table).ToString(), this, controlMouseLocationB);
						b = true;
					}
					break;
			}
		}

		[EditorBrowsable]
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if (e.Location == mouse)
				return;
			else
				mouse = e.Location;

			Rectangle matrix = Matrix;
			relativeMouseLocation = controlMouseLocationC = controlMouseLocationB = controlMouseLocationBB = e.Location;
			controlMouseLocationC.Offset(15, 25);
			controlMouseLocationB.Offset(15, -25);
			controlMouseLocationBB.Offset(15, -5);
			relativeMouseLocation.Offset(-matrix.X, -matrix.Y);

			if (showCoordinateToolTip)
				toolTipC.Show(relativeMouseLocation.X + "," + relativeMouseLocation.Y, this, controlMouseLocationC);

			switch (drawingMode)
			{
				case DrawingMode.Point:
					if (LeftOrRightMouse)
					{
						Point = relativeMouseLocation;
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = point).ToString(), this, controlMouseLocationB);
					}
					break;
				case DrawingMode.Vector:
					if (LeftOrRightMouse)
					{
						Vector = new Point((e.X - matrix.X - matrix.Width / 2 - imageIndent) / vectorDivision, (e.Y - matrix.Y - matrix.Height / 2 - imageIndent) / vectorDivision);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = vector).ToString(), this, controlMouseLocationB);
					}
					break;
				case DrawingMode.Rectangle:
					if (LeftOrRightMouse)
					{
						if (e.Location != rectangle.Location)
							Rectangle = Rectangle.FromLTRB(rectangle.X, rectangle.Y, e.X - Matrix.X == rectangle.X ? rectangle.Right : e.X - Matrix.X, e.Y - Matrix.Y == rectangle.Y ? rectangle.Bottom : e.Y - Matrix.Y);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = Rectangle).ToString(), this, controlMouseLocationB);
					}
					break;
				case DrawingMode.Zwidth:
					if (LeftOrRightMouse)
					{
						Zwidth = Math.Abs(e.Y - matrix.Y);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = zwidth).ToString(), this, controlMouseLocationB);
					}
					break;
				case DrawingMode.Center:
					if (LeftOrRightMouse)
					{
						Center = relativeMouseLocation;
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = center).ToString(), this, controlMouseLocationB);
					}
					break;
				case DrawingMode.RectangleVector:
					if (LeftMouse)
					{
						if (e.Location != rectangle.Location)
							Rectangle = Rectangle.FromLTRB(rectangle.X, rectangle.Y, e.X - Matrix.X == rectangle.X ? rectangle.Right : e.X - Matrix.X, e.Y - Matrix.Y == rectangle.Y ? rectangle.Bottom : e.Y - Matrix.Y);
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = Rectangle).ToString(), this, controlMouseLocationB);
					}
					if (RightMouse)
					{
						Vector = new Point((e.X - matrix.X - rectangle.X - rectangle.Width / 2) / vectorDivision, (e.Y - matrix.Y - rectangle.Y - rectangle.Height / 2) / vectorDivision);
						if (showBoundToolTip)
							toolTipBB.Show((lastBBounds = vector).ToString(), this, controlMouseLocationBB);
					}
					break;
				case DrawingMode.PointVector:
					if (LeftMouse)
					{
						Point = relativeMouseLocation;
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = point).ToString(), this, controlMouseLocationB);
					}
					if (RightMouse)
					{
						Vector = new Point((e.X - matrix.X - point.X) / vectorDivision, (e.Y - matrix.Y - point.Y) / vectorDivision);
						if (showBoundToolTip)
							toolTipBB.Show((lastBBounds = vector).ToString(), this, controlMouseLocationBB);
					}
					break;
				case DrawingMode.Table:
					if (LeftOrRightMouse)
					{
						Table = relativeMouseLocation;
						if (showBoundToolTip)
							toolTipB.Show((lastBounds = lastBBounds = table).ToString(), this, controlMouseLocationB);
					}
					break;
			}
		}

		[EditorBrowsable]
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if ((e.Button & MouseButtons.Left) != 0)
				leftMouse = false;
			if ((e.Button & MouseButtons.Right) != 0)
				rightMouse = false;
			if ((e.Button & MouseButtons.Middle) != 0)
				middleMouse = false;

			if (showBoundToolTip && drawingMode != DrawingMode.None)
			{
				if (b && !leftMouse)
				{
					toolTipB.Show(lastBounds.ToString(), this, controlMouseLocationB, 100);
					b = false;
				}
				if (bb && !rightMouse)
				{
					toolTipBB.Show(lastBBounds.ToString(), this, controlMouseLocationBB, 100);
					bb = false;
				}
			}
		}

		[EditorBrowsable]
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (showCoordinateToolTip)
				toolTipC.Show(relativeMouseLocation.X + "," + relativeMouseLocation.Y, this, controlMouseLocationC, 1);
			if (autoRefresh) this.Refresh();
		}

		#endregion
	}
}
