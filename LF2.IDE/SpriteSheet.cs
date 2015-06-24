using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LF2.IDE
{
	public class SpriteSheet
	{
		Bitmap sprite;
		Size size;
		Size space;
		// Watch out! LF2 use these for each other (row <=> col) (Used normally in code)
		int row, col;

		public Bitmap Sprite
		{
			get { return sprite; }
		}

		public Size Size
		{
			get { return size; }
		}

		public Size Space
		{
			get { return space; }
		}

		public SpriteSheet(Bitmap sprite, Size size, Size space)
		{
			this.sprite = sprite;
			this.size = size;
			this.space = space;
			row = sprite.Width / (size.Width + space.Width);
			col = sprite.Height / (size.Height + space.Height);
		}

		public Bitmap this[int index]
		{
			get
			{
				return this[index % col, index / row];
			}
		}

		public Bitmap this[int x, int y]
		{
			get
			{
				Bitmap result = new Bitmap(size.Width, size.Height);
				using (Graphics gr = Graphics.FromImage(result))
					gr.DrawImage(sprite, new Rectangle(0, 0, size.Width, size.Height), new Rectangle(x * (size.Width + space.Width), y * (size.Height + space.Height), size.Width, size.Height), GraphicsUnit.Pixel);
				return result;
			}
		}

		public Rectangle GetArea(int index)
		{
			return GetArea(index % col, index / row);
		}

		public Rectangle GetArea(int x, int y)
		{
			return new Rectangle(x * (size.Width + space.Width), y * (size.Height + space.Height), size.Width, size.Height);
		}
	}
}
