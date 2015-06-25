using System;
using System.Drawing;

namespace LF2.IDE
{
	public class SpriteSheet
	{
		public SpriteSheet() { }

		public SpriteSheet(int startIndex, int endIndex, string file, Bitmap sprite, int w, int h, int row, int col)
		{
			this.file = file;
			this.startIndex = startIndex;
			this.endIndex = endIndex;
			this.sprite = sprite;
			this.w = w;
			this.h = h;
			this.row = row;
			this.col = col;
		}

		public Bitmap sprite;

		public string file;
		public int w;
		public int h;
		public int row;
		public int col;
		public int startIndex;
		public int endIndex;

		public const string regexPattern = @"file\((\d*)-(\d*)\): *(.*) *w: *(\d*) *h: *(\d*) *row: *(\d*) *col: *(\d*)";

		public override string ToString()
		{
			return ("file(" + startIndex + "-" + endIndex + ")" + ": " + file + "  w: " + w + "  h: " + h + "  row: " + row + "  col: " + col);
		}
	}
}
