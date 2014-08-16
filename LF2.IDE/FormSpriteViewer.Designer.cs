namespace LF2.IDE
{
	partial class FormSpriteViewer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.drawBox = new DrawBox.DrawBox();
			this.SuspendLayout();
			// 
			// drawBox
			// 
			this.drawBox.DisplayMode = DrawBox.DisplayModes.Table;
			this.drawBox.DrawingMode = DrawBox.DrawingMode.Table;
			this.drawBox.Location = new System.Drawing.Point(0, 0);
			this.drawBox.Name = "drawBox";
			this.drawBox.PictureMode = DrawBox.PictureMode.AutoSize;
			this.drawBox.Rectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.drawBox.ShowCoordinateToolTip = true;
			this.drawBox.Size = new System.Drawing.Size(100, 100);
			this.drawBox.TabIndex = 0;
			this.drawBox.TabStop = false;
			// 
			// FormSpriteViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(294, 268);
			this.Controls.Add(this.drawBox);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSpriteViewer";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sprite";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPicFormClosed);
			this.Load += new System.EventHandler(this.FormPic_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPicKeyDown);
			this.ResumeLayout(false);

		}
		private DrawBox.DrawBox drawBox;

		#endregion

	}
}
