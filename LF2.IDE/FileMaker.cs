using System;
using System.Drawing;

namespace LF2.IDE
{
	public class FileMaker
	{
		public FileMaker(int startIndex, int endIndex, string name, Bitmap image, int w, int h, int row, int col)
			: base()
		{
			this.name = name;
			this.startIndex = startIndex;
			this.endIndex = endIndex;
			this.image = image;
			this.w = w;
			this.h = h;
			this.row = row;
			this.col = col;
		}

		public string name;
		public Bitmap image;
		public int w, h, row, col;
		public int startIndex, endIndex;

		public const string regexPattern = @"file\((\d*)-(\d*)\): *(.*) *w: *(\d*) *h: *(\d*) *row: *(\d*) *col: *(\d*)";

		public override string ToString()
		{
			return ("file(" + startIndex + "-" + endIndex + ")" + ": " + name + "  w: " + w + "  h: " + h + "  row: " + row + "  col: " + col);
		}
	}
}
