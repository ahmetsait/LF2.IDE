using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[ProtoContract]
class SpriteSheet2
{
	Bitmap sprite;
	Size size;
	Size space;
	// Watch out! LF2 use these for each other (row <=> col) (Used normally in code)
	int row;
	int col;
	int indexStart;
	int indexEnd;

	public Bitmap Sprite
	{
		get { return sprite; }
	}

	[ProtoMember(1)]
	public Size Size
	{
		get { return size; }
	}

	[ProtoMember(2)]
	public Size Space
	{
		get { return space; }
	}

	[ProtoMember(3)]
	public int Row
	{
		get { return row; }
		set { row = value; }
	}

	[ProtoMember(4)]
	public int Col
	{
		get { return col; }
		set { col = value; }
	}

	[ProtoMember(5)]
	public int IndexStart
	{
		get { return indexStart; }
		set { indexStart = value; }
	}

	[ProtoMember(6)]
	public int IndexEnd
	{
		get { return indexEnd; }
		set { indexEnd = value; }
	}

	public SpriteSheet2() { }

	public SpriteSheet2(Bitmap sprite, Size size, Size space, int indexStart, int indexEnd)
	{
		this.sprite = sprite;
		this.size = size;
		this.space = space;
		row = sprite.Width / (size.Width + space.Width);
		col = sprite.Height / (size.Height + space.Height);
		this.indexStart = indexStart;
		this.indexEnd = indexEnd;
	}

	public Bitmap this[int imageIndex]
	{
		get
		{
			return this[(imageIndex - indexStart) % col, (imageIndex - indexStart) / row];
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

	public Rectangle GetArea(int imageIndex)
	{
		return GetArea((imageIndex - indexStart) % col, (imageIndex - indexStart) / row);
	}

	public Rectangle GetArea(int x, int y)
	{
		return new Rectangle(x * (size.Width + space.Width), y * (size.Height + space.Height), size.Width, size.Height);
	}
}
