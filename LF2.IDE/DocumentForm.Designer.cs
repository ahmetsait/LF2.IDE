namespace LF2.IDE
{
	partial class DocumentForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentForm));
			this.scintilla = new ScintillaNET.Scintilla();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.scintilla)).BeginInit();
			this.SuspendLayout();
			// 
			// scintilla
			// 
			this.scintilla.AllowDrop = true;
			this.scintilla.AutoComplete.ListString = "";
			this.scintilla.AutoComplete.MaxHeight = 8;
			this.scintilla.AutoComplete.SingleLineAccept = true;
			this.scintilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.scintilla.Caret.CurrentLineBackgroundColor = System.Drawing.Color.Lavender;
			this.scintilla.Caret.HighlightCurrentLine = true;
			this.scintilla.ConfigurationManager.CustomLocation = "data.lang.xml";
			this.scintilla.ConfigurationManager.Language = "dat";
			this.scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scintilla.Folding.UseCompactFolding = true;
			this.scintilla.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.scintilla.Indentation.TabWidth = 3;
			this.scintilla.Indentation.UseTabs = false;
			this.scintilla.Lexing.Lexer = ScintillaNET.Lexer.Null;
			this.scintilla.Lexing.LexerName = "null";
			this.scintilla.Lexing.LineCommentPrefix = "";
			this.scintilla.Lexing.StreamCommentPrefix = "";
			this.scintilla.Lexing.StreamCommentSufix = "";
			this.scintilla.Location = new System.Drawing.Point(0, 0);
			this.scintilla.LongLines.EdgeColor = System.Drawing.Color.Red;
			this.scintilla.Margins.FoldMarginColor = System.Drawing.Color.WhiteSmoke;
			this.scintilla.Margins.FoldMarginHighlightColor = System.Drawing.Color.WhiteSmoke;
			this.scintilla.Margins.Left = 5;
			this.scintilla.Margins.Margin0.Width = 38;
			this.scintilla.Margins.Margin1.AutoToggleMarkerNumber = 0;
			this.scintilla.Margins.Margin1.IsClickable = true;
			this.scintilla.Margins.Margin2.Width = 16;
			this.scintilla.Name = "scintilla";
			this.scintilla.Scrolling.HorizontalWidth = 1;
			this.scintilla.Size = new System.Drawing.Size(292, 274);
			this.scintilla.Snippets.ActiveSnippetColor = System.Drawing.Color.DarkBlue;
			this.scintilla.Styles.BraceBad.Size = 9F;
			this.scintilla.Styles.BraceLight.Size = 9F;
			this.scintilla.Styles.ControlChar.Size = 9F;
			this.scintilla.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
			this.scintilla.Styles.Default.Size = 9F;
			this.scintilla.Styles.IndentGuide.Size = 9F;
			this.scintilla.Styles.LastPredefined.Size = 9F;
			this.scintilla.Styles.LineNumber.BackColor = System.Drawing.SystemColors.ControlLight;
			this.scintilla.Styles.LineNumber.FontName = "Courier New";
			this.scintilla.Styles.LineNumber.ForeColor = System.Drawing.Color.Navy;
			this.scintilla.Styles.LineNumber.Size = 9.75F;
			this.scintilla.Styles.Max.Size = 9F;
			this.scintilla.TabIndex = 0;
			this.scintilla.TabStop = false;
			this.scintilla.CharAdded += new System.EventHandler<ScintillaNET.CharAddedEventArgs>(this.ScintillaCharAdded);
			this.scintilla.ModifiedChanged += new System.EventHandler(this.scintilla_ModifiedChanged);
			this.scintilla.ZoomChanged += new System.EventHandler(this.ScintillaZoomChanged);
			this.scintilla.TextChanged += new System.EventHandler(this.ScintillaTextChanged);
			this.scintilla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScintillaKeyPress);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = resources.GetString("saveFileDialog.Filter");
			// 
			// DocumentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 274);
			this.Controls.Add(this.scintilla);
			this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DocumentForm";
			this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.TabText = "Untitled";
			this.Text = "Untitled";
			this.Activated += new System.EventHandler(this.DocumentFormActivated);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocumentForm_FormClosing);
			this.Load += new System.EventHandler(this.DocumentFormLoad);
			this.Enter += new System.EventHandler(this.DocumentFormActivated);
			((System.ComponentModel.ISupportInitialize)(this.scintilla)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public ScintillaNET.Scintilla scintilla;
		public System.Windows.Forms.SaveFileDialog saveFileDialog;

	}
}
