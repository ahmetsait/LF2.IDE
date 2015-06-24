namespace LF2.IDE
{
	partial class FormFrame
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFrame));
			this.tabControl3 = new System.Windows.Forms.TabControl();
			this.button_NewLine = new System.Windows.Forms.Button();
			this.button_Clip = new System.Windows.Forms.Button();
			this.label_dvz = new System.Windows.Forms.Label();
			this.dvz = new System.Windows.Forms.TextBox();
			this.numericUoDown_imageIndex = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown_frameIndex = new System.Windows.Forms.NumericUpDown();
			this.button_Generate = new System.Windows.Forms.Button();
			this.richTextBox = new System.Windows.Forms.RichTextBox();
			this.button_Insert = new System.Windows.Forms.Button();
			this.label_hit_j = new System.Windows.Forms.Label();
			this.label_hit_d = new System.Windows.Forms.Label();
			this.label_hit_a = new System.Windows.Forms.Label();
			this.label_centery = new System.Windows.Forms.Label();
			this.label_hit_ja = new System.Windows.Forms.Label();
			this.label_hit_Dj = new System.Windows.Forms.Label();
			this.label_hit_Uj = new System.Windows.Forms.Label();
			this.label_hit_Fj = new System.Windows.Forms.Label();
			this.label_hit_Da = new System.Windows.Forms.Label();
			this.label_hit_Ua = new System.Windows.Forms.Label();
			this.label_hit_Fa = new System.Windows.Forms.Label();
			this.label_centerx = new System.Windows.Forms.Label();
			this.label_dvy = new System.Windows.Forms.Label();
			this.label_dvx = new System.Windows.Forms.Label();
			this.label_next = new System.Windows.Forms.Label();
			this.lwaitabel_ = new System.Windows.Forms.Label();
			this.label_state = new System.Windows.Forms.Label();
			this.label_index = new System.Windows.Forms.Label();
			this.nextPlus = new System.Windows.Forms.Button();
			this.nextMinus = new System.Windows.Forms.Button();
			this.hit_j = new System.Windows.Forms.TextBox();
			this.hit_d = new System.Windows.Forms.TextBox();
			this.hit_a = new System.Windows.Forms.TextBox();
			this.hit_ja = new System.Windows.Forms.TextBox();
			this.hit_Dj = new System.Windows.Forms.TextBox();
			this.hit_Uj = new System.Windows.Forms.TextBox();
			this.hit_Fj = new System.Windows.Forms.TextBox();
			this.hit_Da = new System.Windows.Forms.TextBox();
			this.hit_Ua = new System.Windows.Forms.TextBox();
			this.hit_Fa = new System.Windows.Forms.TextBox();
			this.centery = new System.Windows.Forms.TextBox();
			this.centerx = new System.Windows.Forms.TextBox();
			this.dvy = new System.Windows.Forms.TextBox();
			this.dvx = new System.Windows.Forms.TextBox();
			this.wait = new System.Windows.Forms.TextBox();
			this.label_caption = new System.Windows.Forms.Label();
			this.label_pic = new System.Windows.Forms.Label();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.label_stateHint = new System.Windows.Forms.Label();
			this.button_Clear = new System.Windows.Forms.Button();
			this.sound = new System.Windows.Forms.TextBox();
			this.label_sound = new System.Windows.Forms.Label();
			this.checkBox_AddTags = new System.Windows.Forms.CheckBox();
			this.state = new System.Windows.Forms.ComboBox();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.nextOfLastFrame = new System.Windows.Forms.ComboBox();
			this.label_nextOfLastFrame = new System.Windows.Forms.Label();
			this.ComboBox_caption = new System.Windows.Forms.ComboBox();
			this.drawBox = new DrawBox.DrawBox();
			this.frameCount = new System.Windows.Forms.NumericUpDown();
			this.next = new System.Windows.Forms.TextBox();
			this.label_frameCount = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numericUoDown_imageIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_frameIndex)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.frameCount)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl3
			// 
			this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl3.Location = new System.Drawing.Point(3, 3);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new System.Drawing.Size(828, 484);
			this.tabControl3.TabIndex = 4;
			this.tabControl3.TabStop = false;
			// 
			// button_NewLine
			// 
			this.button_NewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_NewLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button_NewLine.Location = new System.Drawing.Point(265, 32);
			this.button_NewLine.Name = "button_NewLine";
			this.button_NewLine.Size = new System.Drawing.Size(24, 23);
			this.button_NewLine.TabIndex = 25;
			this.button_NewLine.Text = "NL";
			this.toolTip.SetToolTip(this.button_NewLine, "Insert new line to document");
			this.button_NewLine.UseCompatibleTextRendering = true;
			this.button_NewLine.UseVisualStyleBackColor = true;
			this.button_NewLine.Click += new System.EventHandler(this.NewLine);
			// 
			// button_Clip
			// 
			this.button_Clip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Clip.Location = new System.Drawing.Point(189, 372);
			this.button_Clip.Name = "button_Clip";
			this.button_Clip.Size = new System.Drawing.Size(35, 23);
			this.button_Clip.TabIndex = 26;
			this.button_Clip.TabStop = false;
			this.button_Clip.Text = "Clip";
			this.toolTip.SetToolTip(this.button_Clip, "Copy to Clipboard");
			this.button_Clip.UseVisualStyleBackColor = true;
			this.button_Clip.Click += new System.EventHandler(this.CopyToClipboard);
			// 
			// label_dvz
			// 
			this.label_dvz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_dvz.AutoSize = true;
			this.label_dvz.Location = new System.Drawing.Point(11, 323);
			this.label_dvz.Name = "label_dvz";
			this.label_dvz.Size = new System.Drawing.Size(30, 13);
			this.label_dvz.TabIndex = 25;
			this.label_dvz.Text = "dvz :";
			// 
			// dvz
			// 
			this.dvz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.dvz.Location = new System.Drawing.Point(47, 320);
			this.dvz.Name = "dvz";
			this.dvz.Size = new System.Drawing.Size(60, 20);
			this.dvz.TabIndex = 9;
			// 
			// numericUoDown_imageIndex
			// 
			this.numericUoDown_imageIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUoDown_imageIndex.Location = new System.Drawing.Point(134, 164);
			this.numericUoDown_imageIndex.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.numericUoDown_imageIndex.Name = "numericUoDown_imageIndex";
			this.numericUoDown_imageIndex.Size = new System.Drawing.Size(52, 20);
			this.numericUoDown_imageIndex.TabIndex = 3;
			this.numericUoDown_imageIndex.ValueChanged += new System.EventHandler(this.ImageIndexChanged);
			// 
			// numericUpDown_frameIndex
			// 
			this.numericUpDown_frameIndex.Location = new System.Drawing.Point(55, 6);
			this.numericUpDown_frameIndex.Maximum = new decimal(new int[] {
            399,
            0,
            0,
            0});
			this.numericUpDown_frameIndex.Name = "numericUpDown_frameIndex";
			this.numericUpDown_frameIndex.Size = new System.Drawing.Size(110, 20);
			this.numericUpDown_frameIndex.TabIndex = 1;
			this.numericUpDown_frameIndex.ValueChanged += new System.EventHandler(this.FrameIndexChanged);
			// 
			// button_Generate
			// 
			this.button_Generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Generate.Location = new System.Drawing.Point(230, 372);
			this.button_Generate.Name = "button_Generate";
			this.button_Generate.Size = new System.Drawing.Size(59, 23);
			this.button_Generate.TabIndex = 23;
			this.button_Generate.Text = "Generate";
			this.button_Generate.UseVisualStyleBackColor = true;
			this.button_Generate.Click += new System.EventHandler(this.Generate);
			// 
			// richTextBox
			// 
			this.richTextBox.AcceptsTab = true;
			this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox.DetectUrls = false;
			this.richTextBox.EnableAutoDragDrop = true;
			this.richTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.richTextBox.Location = new System.Drawing.Point(3, 3);
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.Size = new System.Drawing.Size(256, 86);
			this.richTextBox.TabIndex = 23;
			this.richTextBox.TabStop = false;
			this.richTextBox.Text = "";
			this.richTextBox.WordWrap = false;
			this.richTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTextBoxKeyDown);
			// 
			// button_Insert
			// 
			this.button_Insert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Insert.Location = new System.Drawing.Point(265, 3);
			this.button_Insert.Name = "button_Insert";
			this.button_Insert.Size = new System.Drawing.Size(24, 23);
			this.button_Insert.TabIndex = 24;
			this.button_Insert.Text = "+";
			this.toolTip.SetToolTip(this.button_Insert, "Insert frames to document");
			this.button_Insert.UseCompatibleTextRendering = true;
			this.button_Insert.Click += new System.EventHandler(this.Insert);
			// 
			// label_hit_j
			// 
			this.label_hit_j.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_hit_j.AutoSize = true;
			this.label_hit_j.Location = new System.Drawing.Point(189, 243);
			this.label_hit_j.Name = "label_hit_j";
			this.label_hit_j.Size = new System.Drawing.Size(32, 13);
			this.label_hit_j.TabIndex = 0;
			this.label_hit_j.Text = "hit_j :";
			// 
			// label_hit_d
			// 
			this.label_hit_d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_hit_d.AutoSize = true;
			this.label_hit_d.Location = new System.Drawing.Point(189, 217);
			this.label_hit_d.Name = "label_hit_d";
			this.label_hit_d.Size = new System.Drawing.Size(36, 13);
			this.label_hit_d.TabIndex = 0;
			this.label_hit_d.Text = "hit_d :";
			// 
			// label_hit_a
			// 
			this.label_hit_a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_hit_a.AutoSize = true;
			this.label_hit_a.Location = new System.Drawing.Point(189, 191);
			this.label_hit_a.Name = "label_hit_a";
			this.label_hit_a.Size = new System.Drawing.Size(36, 13);
			this.label_hit_a.TabIndex = 0;
			this.label_hit_a.Text = "hit_a :";
			// 
			// label_centery
			// 
			this.label_centery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_centery.AutoSize = true;
			this.label_centery.Location = new System.Drawing.Point(11, 375);
			this.label_centery.Name = "label_centery";
			this.label_centery.Size = new System.Drawing.Size(48, 13);
			this.label_centery.TabIndex = 0;
			this.label_centery.Text = "centery :";
			// 
			// label_hit_ja
			// 
			this.label_hit_ja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_hit_ja.AutoSize = true;
			this.label_hit_ja.Location = new System.Drawing.Point(199, 165);
			this.label_hit_ja.Name = "label_hit_ja";
			this.label_hit_ja.Size = new System.Drawing.Size(38, 13);
			this.label_hit_ja.TabIndex = 0;
			this.label_hit_ja.Text = "hit_ja :";
			// 
			// label_hit_Dj
			// 
			this.label_hit_Dj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_hit_Dj.AutoSize = true;
			this.label_hit_Dj.Location = new System.Drawing.Point(199, 139);
			this.label_hit_Dj.Name = "label_hit_Dj";
			this.label_hit_Dj.Size = new System.Drawing.Size(40, 13);
			this.label_hit_Dj.TabIndex = 0;
			this.label_hit_Dj.Text = "hit_Dj :";
			// 
			// label_hit_Uj
			// 
			this.label_hit_Uj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_hit_Uj.AutoSize = true;
			this.label_hit_Uj.Location = new System.Drawing.Point(199, 113);
			this.label_hit_Uj.Name = "label_hit_Uj";
			this.label_hit_Uj.Size = new System.Drawing.Size(40, 13);
			this.label_hit_Uj.TabIndex = 0;
			this.label_hit_Uj.Text = "hit_Uj :";
			// 
			// label_hit_Fj
			// 
			this.label_hit_Fj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_hit_Fj.AutoSize = true;
			this.label_hit_Fj.Location = new System.Drawing.Point(199, 87);
			this.label_hit_Fj.Name = "label_hit_Fj";
			this.label_hit_Fj.Size = new System.Drawing.Size(38, 13);
			this.label_hit_Fj.TabIndex = 0;
			this.label_hit_Fj.Text = "hit_Fj :";
			// 
			// label_hit_Da
			// 
			this.label_hit_Da.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_hit_Da.AutoSize = true;
			this.label_hit_Da.Location = new System.Drawing.Point(199, 61);
			this.label_hit_Da.Name = "label_hit_Da";
			this.label_hit_Da.Size = new System.Drawing.Size(44, 13);
			this.label_hit_Da.TabIndex = 0;
			this.label_hit_Da.Text = "hit_Da :";
			// 
			// label_hit_Ua
			// 
			this.label_hit_Ua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_hit_Ua.AutoSize = true;
			this.label_hit_Ua.Location = new System.Drawing.Point(199, 35);
			this.label_hit_Ua.Name = "label_hit_Ua";
			this.label_hit_Ua.Size = new System.Drawing.Size(44, 13);
			this.label_hit_Ua.TabIndex = 0;
			this.label_hit_Ua.Text = "hit_Ua :";
			// 
			// label_hit_Fa
			// 
			this.label_hit_Fa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_hit_Fa.AutoSize = true;
			this.label_hit_Fa.Location = new System.Drawing.Point(199, 9);
			this.label_hit_Fa.Name = "label_hit_Fa";
			this.label_hit_Fa.Size = new System.Drawing.Size(42, 13);
			this.label_hit_Fa.TabIndex = 0;
			this.label_hit_Fa.Text = "hit_Fa :";
			// 
			// label_centerx
			// 
			this.label_centerx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_centerx.AutoSize = true;
			this.label_centerx.Location = new System.Drawing.Point(11, 349);
			this.label_centerx.Name = "label_centerx";
			this.label_centerx.Size = new System.Drawing.Size(48, 13);
			this.label_centerx.TabIndex = 0;
			this.label_centerx.Text = "centerx :";
			// 
			// label_dvy
			// 
			this.label_dvy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_dvy.AutoSize = true;
			this.label_dvy.Location = new System.Drawing.Point(11, 297);
			this.label_dvy.Name = "label_dvy";
			this.label_dvy.Size = new System.Drawing.Size(30, 13);
			this.label_dvy.TabIndex = 0;
			this.label_dvy.Text = "dvy :";
			// 
			// label_dvx
			// 
			this.label_dvx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_dvx.AutoSize = true;
			this.label_dvx.Location = new System.Drawing.Point(11, 271);
			this.label_dvx.Name = "label_dvx";
			this.label_dvx.Size = new System.Drawing.Size(30, 13);
			this.label_dvx.TabIndex = 0;
			this.label_dvx.Text = "dvx :";
			// 
			// label_next
			// 
			this.label_next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_next.AutoSize = true;
			this.label_next.Location = new System.Drawing.Point(11, 245);
			this.label_next.Name = "label_next";
			this.label_next.Size = new System.Drawing.Size(33, 13);
			this.label_next.TabIndex = 0;
			this.label_next.Text = "next :";
			// 
			// lwaitabel_
			// 
			this.lwaitabel_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lwaitabel_.AutoSize = true;
			this.lwaitabel_.Location = new System.Drawing.Point(11, 219);
			this.lwaitabel_.Name = "lwaitabel_";
			this.lwaitabel_.Size = new System.Drawing.Size(32, 13);
			this.lwaitabel_.TabIndex = 0;
			this.lwaitabel_.Text = "wait :";
			// 
			// label_state
			// 
			this.label_state.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_state.AutoSize = true;
			this.label_state.Location = new System.Drawing.Point(11, 193);
			this.label_state.Name = "label_state";
			this.label_state.Size = new System.Drawing.Size(36, 13);
			this.label_state.TabIndex = 0;
			this.label_state.Text = "state :";
			// 
			// label_index
			// 
			this.label_index.AutoSize = true;
			this.label_index.Location = new System.Drawing.Point(11, 8);
			this.label_index.Name = "label_index";
			this.label_index.Size = new System.Drawing.Size(38, 13);
			this.label_index.TabIndex = 0;
			this.label_index.Text = "index :";
			// 
			// nextPlus
			// 
			this.nextPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.nextPlus.Location = new System.Drawing.Point(141, 242);
			this.nextPlus.Name = "nextPlus";
			this.nextPlus.Size = new System.Drawing.Size(36, 20);
			this.nextPlus.TabIndex = 7;
			this.nextPlus.TabStop = false;
			this.nextPlus.Text = "1";
			this.toolTip.SetToolTip(this.nextPlus, "next = index + 1");
			this.nextPlus.UseCompatibleTextRendering = true;
			this.nextPlus.UseVisualStyleBackColor = true;
			this.nextPlus.Click += new System.EventHandler(this.NextPlus);
			// 
			// nextMinus
			// 
			this.nextMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.nextMinus.Location = new System.Drawing.Point(106, 242);
			this.nextMinus.Name = "nextMinus";
			this.nextMinus.Size = new System.Drawing.Size(36, 20);
			this.nextMinus.TabIndex = 7;
			this.nextMinus.TabStop = false;
			this.nextMinus.Text = "-1";
			this.toolTip.SetToolTip(this.nextMinus, "next = index - 1");
			this.nextMinus.UseCompatibleTextRendering = true;
			this.nextMinus.UseVisualStyleBackColor = true;
			this.nextMinus.Click += new System.EventHandler(this.NextMinus);
			// 
			// hit_j
			// 
			this.hit_j.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hit_j.Location = new System.Drawing.Point(243, 240);
			this.hit_j.Name = "hit_j";
			this.hit_j.Size = new System.Drawing.Size(46, 20);
			this.hit_j.TabIndex = 13;
			this.hit_j.Text = "0";
			// 
			// hit_d
			// 
			this.hit_d.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hit_d.Location = new System.Drawing.Point(243, 214);
			this.hit_d.Name = "hit_d";
			this.hit_d.Size = new System.Drawing.Size(46, 20);
			this.hit_d.TabIndex = 12;
			this.hit_d.Text = "0";
			// 
			// hit_a
			// 
			this.hit_a.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hit_a.Location = new System.Drawing.Point(243, 188);
			this.hit_a.Name = "hit_a";
			this.hit_a.Size = new System.Drawing.Size(46, 20);
			this.hit_a.TabIndex = 11;
			this.hit_a.Text = "0";
			// 
			// hit_ja
			// 
			this.hit_ja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hit_ja.Location = new System.Drawing.Point(243, 162);
			this.hit_ja.Name = "hit_ja";
			this.hit_ja.Size = new System.Drawing.Size(46, 20);
			this.hit_ja.TabIndex = 20;
			// 
			// hit_Dj
			// 
			this.hit_Dj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hit_Dj.Location = new System.Drawing.Point(243, 136);
			this.hit_Dj.Name = "hit_Dj";
			this.hit_Dj.Size = new System.Drawing.Size(46, 20);
			this.hit_Dj.TabIndex = 19;
			// 
			// hit_Uj
			// 
			this.hit_Uj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hit_Uj.Location = new System.Drawing.Point(243, 110);
			this.hit_Uj.Name = "hit_Uj";
			this.hit_Uj.Size = new System.Drawing.Size(46, 20);
			this.hit_Uj.TabIndex = 18;
			// 
			// hit_Fj
			// 
			this.hit_Fj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hit_Fj.Location = new System.Drawing.Point(243, 84);
			this.hit_Fj.Name = "hit_Fj";
			this.hit_Fj.Size = new System.Drawing.Size(46, 20);
			this.hit_Fj.TabIndex = 17;
			// 
			// hit_Da
			// 
			this.hit_Da.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hit_Da.Location = new System.Drawing.Point(243, 58);
			this.hit_Da.Name = "hit_Da";
			this.hit_Da.Size = new System.Drawing.Size(46, 20);
			this.hit_Da.TabIndex = 16;
			// 
			// hit_Ua
			// 
			this.hit_Ua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hit_Ua.Location = new System.Drawing.Point(243, 32);
			this.hit_Ua.Name = "hit_Ua";
			this.hit_Ua.Size = new System.Drawing.Size(46, 20);
			this.hit_Ua.TabIndex = 15;
			// 
			// hit_Fa
			// 
			this.hit_Fa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.hit_Fa.Location = new System.Drawing.Point(243, 6);
			this.hit_Fa.Name = "hit_Fa";
			this.hit_Fa.Size = new System.Drawing.Size(46, 20);
			this.hit_Fa.TabIndex = 14;
			// 
			// centery
			// 
			this.centery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.centery.Location = new System.Drawing.Point(65, 372);
			this.centery.Name = "centery";
			this.centery.Size = new System.Drawing.Size(42, 20);
			this.centery.TabIndex = 10;
			this.centery.Text = "79";
			// 
			// centerx
			// 
			this.centerx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.centerx.Location = new System.Drawing.Point(65, 346);
			this.centerx.Name = "centerx";
			this.centerx.Size = new System.Drawing.Size(42, 20);
			this.centerx.TabIndex = 9;
			this.centerx.Text = "39";
			// 
			// dvy
			// 
			this.dvy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.dvy.Location = new System.Drawing.Point(47, 294);
			this.dvy.Name = "dvy";
			this.dvy.Size = new System.Drawing.Size(60, 20);
			this.dvy.TabIndex = 8;
			this.dvy.Text = "0";
			// 
			// dvx
			// 
			this.dvx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.dvx.Location = new System.Drawing.Point(47, 268);
			this.dvx.Name = "dvx";
			this.dvx.Size = new System.Drawing.Size(60, 20);
			this.dvx.TabIndex = 7;
			this.dvx.Text = "0";
			// 
			// wait
			// 
			this.wait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.wait.Location = new System.Drawing.Point(49, 216);
			this.wait.Name = "wait";
			this.wait.Size = new System.Drawing.Size(58, 20);
			this.wait.TabIndex = 5;
			this.wait.Text = "0";
			// 
			// label_caption
			// 
			this.label_caption.AutoSize = true;
			this.label_caption.Location = new System.Drawing.Point(11, 34);
			this.label_caption.Name = "label_caption";
			this.label_caption.Size = new System.Drawing.Size(48, 13);
			this.label_caption.TabIndex = 0;
			this.label_caption.Text = "caption :";
			// 
			// label_pic
			// 
			this.label_pic.AutoSize = true;
			this.label_pic.Location = new System.Drawing.Point(11, 60);
			this.label_pic.Name = "label_pic";
			this.label_pic.Size = new System.Drawing.Size(27, 13);
			this.label_pic.TabIndex = 0;
			this.label_pic.Text = "pic :";
			// 
			// toolTip
			// 
			this.toolTip.AutoPopDelay = 30000;
			this.toolTip.InitialDelay = 500;
			this.toolTip.ReshowDelay = 100;
			this.toolTip.UseAnimation = false;
			this.toolTip.UseFading = false;
			// 
			// label_stateHint
			// 
			this.label_stateHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label_stateHint.AutoSize = true;
			this.label_stateHint.Location = new System.Drawing.Point(113, 193);
			this.label_stateHint.Name = "label_stateHint";
			this.label_stateHint.Size = new System.Drawing.Size(26, 13);
			this.label_stateHint.TabIndex = 0;
			this.label_stateHint.Text = "Hint";
			this.toolTip.SetToolTip(this.label_stateHint, resources.GetString("label_stateHint.ToolTip"));
			// 
			// button_Clear
			// 
			this.button_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button_Clear.Location = new System.Drawing.Point(154, 372);
			this.button_Clear.Name = "button_Clear";
			this.button_Clear.Size = new System.Drawing.Size(29, 23);
			this.button_Clear.TabIndex = 27;
			this.button_Clear.TabStop = false;
			this.button_Clear.Text = "C";
			this.toolTip.SetToolTip(this.button_Clear, "Clear");
			this.button_Clear.UseVisualStyleBackColor = true;
			this.button_Clear.Click += new System.EventHandler(this.Clear);
			// 
			// sound
			// 
			this.sound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.sound.Location = new System.Drawing.Point(171, 319);
			this.sound.Name = "sound";
			this.sound.Size = new System.Drawing.Size(118, 20);
			this.sound.TabIndex = 21;
			// 
			// label_sound
			// 
			this.label_sound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_sound.AutoSize = true;
			this.label_sound.Location = new System.Drawing.Point(123, 322);
			this.label_sound.Name = "label_sound";
			this.label_sound.Size = new System.Drawing.Size(42, 13);
			this.label_sound.TabIndex = 0;
			this.label_sound.Text = "sound :";
			// 
			// checkBox_AddTags
			// 
			this.checkBox_AddTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox_AddTags.AutoSize = true;
			this.checkBox_AddTags.Location = new System.Drawing.Point(141, 346);
			this.checkBox_AddTags.Name = "checkBox_AddTags";
			this.checkBox_AddTags.Size = new System.Drawing.Size(148, 17);
			this.checkBox_AddTags.TabIndex = 22;
			this.checkBox_AddTags.Text = "Add tags while generating";
			// 
			// state
			// 
			this.state.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.state.FormattingEnabled = true;
			this.state.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "100",
            "301",
            "1700",
            "2000",
            "8000",
            "9995",
            "9996",
            "9997",
            "9998",
            "9999"});
			this.state.Location = new System.Drawing.Point(50, 190);
			this.state.Name = "state";
			this.state.Size = new System.Drawing.Size(57, 21);
			this.state.TabIndex = 4;
			this.state.Text = "0";
			// 
			// splitContainer
			// 
			this.splitContainer.BackColor = System.Drawing.SystemColors.ControlDark;
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer.Panel1.Controls.Add(this.button_Clear);
			this.splitContainer.Panel1.Controls.Add(this.checkBox_AddTags);
			this.splitContainer.Panel1.Controls.Add(this.sound);
			this.splitContainer.Panel1.Controls.Add(this.button_Clip);
			this.splitContainer.Panel1.Controls.Add(this.label_sound);
			this.splitContainer.Panel1.Controls.Add(this.button_Generate);
			this.splitContainer.Panel1.Controls.Add(this.nextOfLastFrame);
			this.splitContainer.Panel1.Controls.Add(this.label_nextOfLastFrame);
			this.splitContainer.Panel1.Controls.Add(this.ComboBox_caption);
			this.splitContainer.Panel1.Controls.Add(this.drawBox);
			this.splitContainer.Panel1.Controls.Add(this.state);
			this.splitContainer.Panel1.Controls.Add(this.label_index);
			this.splitContainer.Panel1.Controls.Add(this.label_stateHint);
			this.splitContainer.Panel1.Controls.Add(this.hit_j);
			this.splitContainer.Panel1.Controls.Add(this.label_dvz);
			this.splitContainer.Panel1.Controls.Add(this.hit_d);
			this.splitContainer.Panel1.Controls.Add(this.label_pic);
			this.splitContainer.Panel1.Controls.Add(this.hit_a);
			this.splitContainer.Panel1.Controls.Add(this.dvz);
			this.splitContainer.Panel1.Controls.Add(this.hit_ja);
			this.splitContainer.Panel1.Controls.Add(this.label_hit_Fa);
			this.splitContainer.Panel1.Controls.Add(this.frameCount);
			this.splitContainer.Panel1.Controls.Add(this.numericUoDown_imageIndex);
			this.splitContainer.Panel1.Controls.Add(this.hit_Dj);
			this.splitContainer.Panel1.Controls.Add(this.label_hit_Ua);
			this.splitContainer.Panel1.Controls.Add(this.numericUpDown_frameIndex);
			this.splitContainer.Panel1.Controls.Add(this.hit_Uj);
			this.splitContainer.Panel1.Controls.Add(this.label_caption);
			this.splitContainer.Panel1.Controls.Add(this.label_hit_Da);
			this.splitContainer.Panel1.Controls.Add(this.hit_Fj);
			this.splitContainer.Panel1.Controls.Add(this.next);
			this.splitContainer.Panel1.Controls.Add(this.wait);
			this.splitContainer.Panel1.Controls.Add(this.label_hit_Fj);
			this.splitContainer.Panel1.Controls.Add(this.hit_Da);
			this.splitContainer.Panel1.Controls.Add(this.dvx);
			this.splitContainer.Panel1.Controls.Add(this.label_hit_Uj);
			this.splitContainer.Panel1.Controls.Add(this.dvy);
			this.splitContainer.Panel1.Controls.Add(this.hit_Ua);
			this.splitContainer.Panel1.Controls.Add(this.centerx);
			this.splitContainer.Panel1.Controls.Add(this.label_hit_Dj);
			this.splitContainer.Panel1.Controls.Add(this.label_centery);
			this.splitContainer.Panel1.Controls.Add(this.hit_Fa);
			this.splitContainer.Panel1.Controls.Add(this.centery);
			this.splitContainer.Panel1.Controls.Add(this.label_hit_ja);
			this.splitContainer.Panel1.Controls.Add(this.label_centerx);
			this.splitContainer.Panel1.Controls.Add(this.label_hit_a);
			this.splitContainer.Panel1.Controls.Add(this.label_dvy);
			this.splitContainer.Panel1.Controls.Add(this.label_hit_d);
			this.splitContainer.Panel1.Controls.Add(this.label_dvx);
			this.splitContainer.Panel1.Controls.Add(this.label_frameCount);
			this.splitContainer.Panel1.Controls.Add(this.label_hit_j);
			this.splitContainer.Panel1.Controls.Add(this.label_next);
			this.splitContainer.Panel1.Controls.Add(this.label_state);
			this.splitContainer.Panel1.Controls.Add(this.nextMinus);
			this.splitContainer.Panel1.Controls.Add(this.nextPlus);
			this.splitContainer.Panel1.Controls.Add(this.lwaitabel_);
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
			this.splitContainer.Panel2.Controls.Add(this.richTextBox);
			this.splitContainer.Panel2.Controls.Add(this.button_Insert);
			this.splitContainer.Panel2.Controls.Add(this.button_NewLine);
			this.splitContainer.Size = new System.Drawing.Size(292, 494);
			this.splitContainer.SplitterDistance = 398;
			this.splitContainer.TabIndex = 0;
			this.splitContainer.TabStop = false;
			// 
			// nextOfLastFrame
			// 
			this.nextOfLastFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.nextOfLastFrame.FormattingEnabled = true;
			this.nextOfLastFrame.Items.AddRange(new object[] {
            "0",
            "1",
            "999",
            "1000"});
			this.nextOfLastFrame.Location = new System.Drawing.Point(243, 292);
			this.nextOfLastFrame.Name = "nextOfLastFrame";
			this.nextOfLastFrame.Size = new System.Drawing.Size(46, 21);
			this.nextOfLastFrame.TabIndex = 30;
			this.nextOfLastFrame.Text = "999";
			// 
			// label_nextOfLastFrame
			// 
			this.label_nextOfLastFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_nextOfLastFrame.AutoSize = true;
			this.label_nextOfLastFrame.Location = new System.Drawing.Point(144, 295);
			this.label_nextOfLastFrame.Name = "label_nextOfLastFrame";
			this.label_nextOfLastFrame.Size = new System.Drawing.Size(93, 13);
			this.label_nextOfLastFrame.TabIndex = 29;
			this.label_nextOfLastFrame.Text = "next of last frame :";
			// 
			// ComboBox_caption
			// 
			this.ComboBox_caption.FormattingEnabled = true;
			this.ComboBox_caption.Items.AddRange(new object[] {
            "standing",
            "walking",
            "running",
            "heavy_obj_walk",
            "heavy_obj_run",
            "heavy_stop_run",
            "normal_weapon_atck",
            "jump_weapon_atck",
            "run_weapon_atck",
            "dash_weapon_atck",
            "light_weapon_thw",
            "heavy_weapon_thw",
            "sky_lgt_wp_thw",
            "weapon_drink",
            "punch",
            "super_punch",
            "jump_attack",
            "run_attack",
            "dash_attack",
            "dash_defend",
            "rowing",
            "defend",
            "broken_defend",
            "picking_light",
            "picking_heavy",
            "catching",
            "picked_caught",
            "falling",
            "ice",
            "fire",
            "tired",
            "jump",
            "dash",
            "crouch",
            "crouch2",
            "stop_running",
            "injured",
            "lying",
            "throw_lying_man",
            "in_the_sky",
            "on_hand",
            "throwing",
            "on_ground",
            "just_on_ground",
            "flying",
            "hiting",
            "hit",
            "rebound",
            "rebounding",
            "tail",
            "hiting_ground"});
			this.ComboBox_caption.Location = new System.Drawing.Point(65, 32);
			this.ComboBox_caption.Name = "ComboBox_caption";
			this.ComboBox_caption.Size = new System.Drawing.Size(100, 21);
			this.ComboBox_caption.TabIndex = 2;
			this.ComboBox_caption.Text = "standing";
			// 
			// drawBox
			// 
			this.drawBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.drawBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("drawBox.BackgroundImage")));
			this.drawBox.Center = new System.Drawing.Point(-1, -1);
			this.drawBox.Cursor = System.Windows.Forms.Cursors.Cross;
			this.drawBox.Interpolation = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			this.drawBox.Location = new System.Drawing.Point(45, 57);
			this.drawBox.Name = "drawBox";
			this.drawBox.PictureMode = DrawBox.PictureMode.ShrinkOnly;
			this.drawBox.Point = new System.Drawing.Point(-1, -1);
			this.drawBox.Rectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.drawBox.Size = new System.Drawing.Size(89, 127);
			this.drawBox.TabIndex = 28;
			this.drawBox.Table = new System.Drawing.Point(-1, -1);
			this.drawBox.TabStop = false;
			this.drawBox.Trancparency = true;
			this.drawBox.Vector = new System.Drawing.Point(-1, -1);
			// 
			// frameCount
			// 
			this.frameCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.frameCount.Location = new System.Drawing.Point(243, 266);
			this.frameCount.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
			this.frameCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.frameCount.Name = "frameCount";
			this.frameCount.Size = new System.Drawing.Size(46, 20);
			this.frameCount.TabIndex = 3;
			this.frameCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.frameCount.ValueChanged += new System.EventHandler(this.ImageIndexChanged);
			// 
			// next
			// 
			this.next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.next.Location = new System.Drawing.Point(49, 242);
			this.next.Name = "next";
			this.next.Size = new System.Drawing.Size(51, 20);
			this.next.TabIndex = 5;
			this.next.Text = "0";
			// 
			// label_frameCount
			// 
			this.label_frameCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label_frameCount.AutoSize = true;
			this.label_frameCount.Location = new System.Drawing.Point(168, 268);
			this.label_frameCount.Name = "label_frameCount";
			this.label_frameCount.Size = new System.Drawing.Size(69, 13);
			this.label_frameCount.TabIndex = 0;
			this.label_frameCount.Text = "frame count :";
			// 
			// FormFrame
			// 
			this.AcceptButton = this.button_Generate;
			this.AutoHidePortion = 300D;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 494);
			this.Controls.Add(this.splitContainer);
			this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.HideOnClose = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormFrame";
			this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.TabText = "Frame";
			this.Text = "Frame";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFrame_Closing);
			((System.ComponentModel.ISupportInitialize)(this.numericUoDown_imageIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_frameIndex)).EndInit();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.frameCount)).EndInit();
			this.ResumeLayout(false);

		}
		public System.Windows.Forms.NumericUpDown frameCount;
		public DrawBox.DrawBox drawBox;
		public System.Windows.Forms.NumericUpDown numericUoDown_imageIndex;
		public System.Windows.Forms.Label label_nextOfLastFrame;
		public System.Windows.Forms.ComboBox nextOfLastFrame;
		public System.Windows.Forms.Label label_frameCount;
		public System.Windows.Forms.TextBox next;
		public System.Windows.Forms.SplitContainer splitContainer;
		public System.Windows.Forms.ComboBox state;
		public System.Windows.Forms.Button button_Clear;
		public System.Windows.Forms.CheckBox checkBox_AddTags;
		public System.Windows.Forms.Label label_stateHint;
		public System.Windows.Forms.Label label_sound;
		public System.Windows.Forms.TextBox sound;
		public System.Windows.Forms.ToolTip toolTip;
		public System.Windows.Forms.Label label_pic;
		public System.Windows.Forms.ComboBox ComboBox_caption;
		public System.Windows.Forms.Label label_caption;
		public System.Windows.Forms.TextBox wait;
		public System.Windows.Forms.TextBox dvx;
		public System.Windows.Forms.TextBox dvy;
		public System.Windows.Forms.TextBox centerx;
		public System.Windows.Forms.TextBox centery;
		public System.Windows.Forms.TextBox hit_Fa;
		public System.Windows.Forms.TextBox hit_Ua;
		public System.Windows.Forms.TextBox hit_Da;
		public System.Windows.Forms.TextBox hit_Fj;
		public System.Windows.Forms.TextBox hit_Uj;
		public System.Windows.Forms.TextBox hit_Dj;
		public System.Windows.Forms.TextBox hit_ja;
		public System.Windows.Forms.TextBox hit_a;
		public System.Windows.Forms.TextBox hit_d;
		public System.Windows.Forms.TextBox hit_j;
		public System.Windows.Forms.Button nextMinus;
		public System.Windows.Forms.Button nextPlus;
		public System.Windows.Forms.Label label_index;
		public System.Windows.Forms.Label label_state;
		public System.Windows.Forms.Label lwaitabel_;
		public System.Windows.Forms.Label label_next;
		public System.Windows.Forms.Label label_dvx;
		public System.Windows.Forms.Label label_dvy;
		public System.Windows.Forms.Label label_centerx;
		public System.Windows.Forms.Label label_hit_Fa;
		public System.Windows.Forms.Label label_hit_Ua;
		public System.Windows.Forms.Label label_hit_Da;
		public System.Windows.Forms.Label label_hit_Fj;
		public System.Windows.Forms.Label label_hit_Uj;
		public System.Windows.Forms.Label label_hit_Dj;
		public System.Windows.Forms.Label label_hit_ja;
		public System.Windows.Forms.Label label_centery;
		public System.Windows.Forms.Label label_hit_a;
		public System.Windows.Forms.Label label_hit_d;
		public System.Windows.Forms.Label label_hit_j;
		public System.Windows.Forms.Button button_Insert;
		public System.Windows.Forms.RichTextBox richTextBox;
		public System.Windows.Forms.Button button_Generate;
		public System.Windows.Forms.NumericUpDown numericUpDown_frameIndex;
		public System.Windows.Forms.TextBox dvz;
		public System.Windows.Forms.Label label_dvz;
		public System.Windows.Forms.Button button_Clip;
		public System.Windows.Forms.Button button_NewLine;
		public System.Windows.Forms.TabControl tabControl3;
	}
}
