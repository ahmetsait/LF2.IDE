
namespace LF2.IDE
{
	partial class FormTextureEditor
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTextureEditor));
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.trackBar_Zoom = new System.Windows.Forms.TrackBar();
			this.toolBox = new System.Windows.Forms.ToolStrip();
			this.reverserToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.pencilToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator_File = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reverseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fillAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ClearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator_Edit = new System.Windows.Forms.ToolStripSeparator();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoTolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fitWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.efectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.effectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.toolStripContainer.ContentPanel.SuspendLayout();
			this.toolStripContainer.LeftToolStripPanel.SuspendLayout();
			this.toolStripContainer.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Zoom)).BeginInit();
			this.toolBox.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pictureBox.Location = new System.Drawing.Point(3, 3);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(345, 226);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseMove);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMouseUp);
			this.pictureBox.Resize += new System.EventHandler(this.PictureBoxResize);
			// 
			// toolStripContainer
			// 
			// 
			// toolStripContainer.ContentPanel
			// 
			this.toolStripContainer.ContentPanel.Controls.Add(this.trackBar_Zoom);
			this.toolStripContainer.ContentPanel.Controls.Add(this.pictureBox);
			this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(351, 263);
			this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			// 
			// toolStripContainer.LeftToolStripPanel
			// 
			this.toolStripContainer.LeftToolStripPanel.Controls.Add(this.toolBox);
			this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer.Name = "toolStripContainer";
			this.toolStripContainer.Size = new System.Drawing.Size(375, 287);
			this.toolStripContainer.TabIndex = 1;
			this.toolStripContainer.TabStop = false;
			this.toolStripContainer.Text = "toolStripContainer1";
			// 
			// toolStripContainer.TopToolStripPanel
			// 
			this.toolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip);
			// 
			// trackBar_Zoom
			// 
			this.trackBar_Zoom.AutoSize = false;
			this.trackBar_Zoom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.trackBar_Zoom.Location = new System.Drawing.Point(0, 235);
			this.trackBar_Zoom.Maximum = 80;
			this.trackBar_Zoom.Minimum = 1;
			this.trackBar_Zoom.Name = "trackBar_Zoom";
			this.trackBar_Zoom.Size = new System.Drawing.Size(351, 28);
			this.trackBar_Zoom.TabIndex = 8;
			this.trackBar_Zoom.TabStop = false;
			this.trackBar_Zoom.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trackBar_Zoom.Value = 8;
			this.trackBar_Zoom.ValueChanged += new System.EventHandler(this.TrackBarZoomValueChanged);
			// 
			// toolBox
			// 
			this.toolBox.Dock = System.Windows.Forms.DockStyle.None;
			this.toolBox.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reverserToolStripButton,
            this.pencilToolStripButton});
			this.toolBox.Location = new System.Drawing.Point(0, 3);
			this.toolBox.Name = "toolBox";
			this.toolBox.Size = new System.Drawing.Size(24, 48);
			this.toolBox.TabIndex = 0;
			this.toolBox.Text = "Tool Box";
			// 
			// reverserToolStripButton
			// 
			this.reverserToolStripButton.Checked = true;
			this.reverserToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.reverserToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.reverserToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("reverserToolStripButton.Image")));
			this.reverserToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.reverserToolStripButton.Name = "reverserToolStripButton";
			this.reverserToolStripButton.Size = new System.Drawing.Size(22, 20);
			this.reverserToolStripButton.Text = "Reverser";
			this.reverserToolStripButton.Click += new System.EventHandler(this.ToolRPencilClick);
			// 
			// pencilToolStripButton
			// 
			this.pencilToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pencilToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pencilToolStripButton.Image")));
			this.pencilToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pencilToolStripButton.Name = "pencilToolStripButton";
			this.pencilToolStripButton.Size = new System.Drawing.Size(22, 20);
			this.pencilToolStripButton.Text = "Pencil";
			this.pencilToolStripButton.Click += new System.EventHandler(this.ToolPencilClick);
			// 
			// menuStrip
			// 
			this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.fitWindowToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(375, 24);
			this.menuStrip.TabIndex = 0;
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator_File,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
			// 
			// toolStripSeparator_File
			// 
			this.toolStripSeparator_File.Name = "toolStripSeparator_File";
			this.toolStripSeparator_File.Size = new System.Drawing.Size(174, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reverseAllToolStripMenuItem,
            this.fillAllToolStripMenuItem,
            this.ClearAllToolStripMenuItem,
            this.toolStripSeparator_Edit,
            this.undoToolStripMenuItem,
            this.redoTolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// reverseAllToolStripMenuItem
			// 
			this.reverseAllToolStripMenuItem.Name = "reverseAllToolStripMenuItem";
			this.reverseAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.reverseAllToolStripMenuItem.Text = "Re&verse All";
			this.reverseAllToolStripMenuItem.Click += new System.EventHandler(this.ReverseAllToolStripMenuItemClick);
			// 
			// fillAllToolStripMenuItem
			// 
			this.fillAllToolStripMenuItem.Name = "fillAllToolStripMenuItem";
			this.fillAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.fillAllToolStripMenuItem.Text = "&Fill All";
			this.fillAllToolStripMenuItem.Click += new System.EventHandler(this.FillAllToolStripMenuItemClick);
			// 
			// ClearAllToolStripMenuItem
			// 
			this.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem";
			this.ClearAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.ClearAllToolStripMenuItem.Text = "&Clear All";
			this.ClearAllToolStripMenuItem.Click += new System.EventHandler(this.ClearAllToolStripMenuItemClick);
			// 
			// toolStripSeparator_Edit
			// 
			this.toolStripSeparator_Edit.Name = "toolStripSeparator_Edit";
			this.toolStripSeparator_Edit.Size = new System.Drawing.Size(149, 6);
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			this.undoToolStripMenuItem.Visible = false;
			this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItemClick);
			// 
			// redoTolStripMenuItem
			// 
			this.redoTolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoTolStripMenuItem.Image")));
			this.redoTolStripMenuItem.Name = "redoTolStripMenuItem";
			this.redoTolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.redoTolStripMenuItem.Text = "&Redo";
			this.redoTolStripMenuItem.Visible = false;
			this.redoTolStripMenuItem.Click += new System.EventHandler(this.RedoToolStripMenuItemClick);
			// 
			// resizeToolStripMenuItem
			// 
			this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
			this.resizeToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
			this.resizeToolStripMenuItem.Text = "&Resize";
			this.resizeToolStripMenuItem.Click += new System.EventHandler(this.ResizeToolStripMenuItemClick);
			// 
			// fitWindowToolStripMenuItem
			// 
			this.fitWindowToolStripMenuItem.Name = "fitWindowToolStripMenuItem";
			this.fitWindowToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
			this.fitWindowToolStripMenuItem.Text = "Fit Window";
			this.fitWindowToolStripMenuItem.Click += new System.EventHandler(this.FitWindowToolStripMenuItemClick);
			// 
			// efectsToolStripMenuItem
			// 
			this.efectsToolStripMenuItem.Name = "efectsToolStripMenuItem";
			this.efectsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			this.efectsToolStripMenuItem.Text = "E&fects";
			// 
			// effectsToolStripMenuItem
			// 
			this.effectsToolStripMenuItem.Name = "effectsToolStripMenuItem";
			this.effectsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
			this.effectsToolStripMenuItem.Text = "E&ffects";
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Texture Files (*.texture)|*.texture";
			this.openFileDialog.ReadOnlyChecked = true;
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "Texture Files (*.texture)|*.texture";
			// 
			// toolTip
			// 
			this.toolTip.AutoPopDelay = 30000;
			this.toolTip.InitialDelay = 500;
			this.toolTip.ReshowDelay = 100;
			// 
			// FormTextureEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(375, 287);
			this.Controls.Add(this.toolStripContainer);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "FormTextureEditor";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Texture Editor";
			this.Load += new System.EventHandler(this.FormBitEditorLoad);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormBitEditKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.toolStripContainer.ContentPanel.ResumeLayout(false);
			this.toolStripContainer.ContentPanel.PerformLayout();
			this.toolStripContainer.LeftToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.LeftToolStripPanel.PerformLayout();
			this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer.TopToolStripPanel.PerformLayout();
			this.toolStripContainer.ResumeLayout(false);
			this.toolStripContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_Zoom)).EndInit();
			this.toolBox.ResumeLayout(false);
			this.toolBox.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.ResumeLayout(false);

		}
		public System.Windows.Forms.TrackBar trackBar_Zoom;
		public System.Windows.Forms.PictureBox pictureBox;
		public System.Windows.Forms.ToolStripMenuItem fitWindowToolStripMenuItem;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator_Edit;
		public System.Windows.Forms.ToolTip toolTip;
		public System.Windows.Forms.SaveFileDialog saveFileDialog;
		public System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		public System.Windows.Forms.OpenFileDialog openFileDialog;
		public System.Windows.Forms.ToolStripMenuItem ClearAllToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem fillAllToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem reverseAllToolStripMenuItem;
		public System.Windows.Forms.ToolStripButton reverserToolStripButton;
		public System.Windows.Forms.ToolStripButton pencilToolStripButton;
		public System.Windows.Forms.ToolStrip toolBox;
		public System.Windows.Forms.ToolStripMenuItem effectsToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem efectsToolStripMenuItem;
		public System.Windows.Forms.ToolStripSeparator toolStripSeparator_File;
		public System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem redoTolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		public System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		public System.Windows.Forms.MenuStrip menuStrip;
		public System.Windows.Forms.ToolStripContainer toolStripContainer;
	}
}
