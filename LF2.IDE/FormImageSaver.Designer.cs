
namespace LF2.IDE
{
	partial class FormImageSaver
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImageSaver));
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxPixelFormat = new System.Windows.Forms.ComboBox();
			this.comboBoxImageFormat = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.propertyGrid = new System.Windows.Forms.PropertyGrid();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Pixel Format :";
			// 
			// comboBoxPixelFormat
			// 
			this.comboBoxPixelFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxPixelFormat.FormattingEnabled = true;
			this.comboBoxPixelFormat.Location = new System.Drawing.Point(88, 12);
			this.comboBoxPixelFormat.Name = "comboBoxPixelFormat";
			this.comboBoxPixelFormat.Size = new System.Drawing.Size(192, 21);
			this.comboBoxPixelFormat.TabIndex = 1;
			// 
			// comboBoxImageFormat
			// 
			this.comboBoxImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxImageFormat.FormattingEnabled = true;
			this.comboBoxImageFormat.Items.AddRange(new object[] {
            "Bmp",
            "MemoryBmp",
            "Png",
            "Jpeg",
            "Gif",
            "Emf",
            "Tiff",
            "Wmf"});
			this.comboBoxImageFormat.Location = new System.Drawing.Point(95, 39);
			this.comboBoxImageFormat.Name = "comboBoxImageFormat";
			this.comboBoxImageFormat.Size = new System.Drawing.Size(185, 21);
			this.comboBoxImageFormat.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Image Format :";
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonOK.Location = new System.Drawing.Point(68, 187);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(149, 187);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = resources.GetString("saveFileDialog.Filter");
			// 
			// propertyGrid
			// 
			this.propertyGrid.HelpVisible = false;
			this.propertyGrid.Location = new System.Drawing.Point(12, 66);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
			this.propertyGrid.Size = new System.Drawing.Size(268, 115);
			this.propertyGrid.TabIndex = 4;
			this.propertyGrid.ToolbarVisible = false;
			// 
			// FormImageSaver
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(292, 222);
			this.Controls.Add(this.propertyGrid);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.comboBoxImageFormat);
			this.Controls.Add(this.comboBoxPixelFormat);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormImageSaver";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Image Saver";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public System.Windows.Forms.PropertyGrid propertyGrid;
		public System.Windows.Forms.SaveFileDialog saveFileDialog;
		public System.Windows.Forms.Button buttonOK;
		public System.Windows.Forms.Button buttonCancel;
		public System.Windows.Forms.ComboBox comboBoxImageFormat;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.ComboBox comboBoxPixelFormat;
		public System.Windows.Forms.Label label1;
	}
}
