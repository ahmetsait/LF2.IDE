namespace LF2.IDE
{
	partial class AboutForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.assemblyVersionLabel = new System.Windows.Forms.Label();
			this.lf2MemoryLabel = new System.Windows.Forms.Label();
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			this.productNameLabel = new System.Windows.Forms.Label();
			this.productVersionLabel = new System.Windows.Forms.Label();
			this.copyrightLabel = new System.Windows.Forms.Label();
			this.companyNameLabel = new System.Windows.Forms.Label();
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.73606F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.26394F));
			this.tableLayoutPanel.Controls.Add(this.assemblyVersionLabel, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.lf2MemoryLabel, 1, 6);
			this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.productNameLabel, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.productVersionLabel, 1, 2);
			this.tableLayoutPanel.Controls.Add(this.copyrightLabel, 1, 3);
			this.tableLayoutPanel.Controls.Add(this.companyNameLabel, 1, 4);
			this.tableLayoutPanel.Controls.Add(this.descriptionTextBox, 1, 5);
			this.tableLayoutPanel.Controls.Add(this.okButton, 0, 6);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 7;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(676, 323);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// assemblyVersionLabel
			// 
			this.assemblyVersionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.assemblyVersionLabel.Location = new System.Drawing.Point(403, 32);
			this.assemblyVersionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.assemblyVersionLabel.MaximumSize = new System.Drawing.Size(0, 17);
			this.assemblyVersionLabel.Name = "assemblyVersionLabel";
			this.assemblyVersionLabel.Size = new System.Drawing.Size(270, 17);
			this.assemblyVersionLabel.TabIndex = 25;
			this.assemblyVersionLabel.Text = "Assembly Version";
			this.assemblyVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lf2MemoryLabel
			// 
			this.lf2MemoryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lf2MemoryLabel.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lf2MemoryLabel.Location = new System.Drawing.Point(403, 291);
			this.lf2MemoryLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.lf2MemoryLabel.MaximumSize = new System.Drawing.Size(0, 17);
			this.lf2MemoryLabel.Name = "lf2MemoryLabel";
			this.lf2MemoryLabel.Size = new System.Drawing.Size(270, 17);
			this.lf2MemoryLabel.TabIndex = 20;
			this.lf2MemoryLabel.Text = "In the Memory of LF2...";
			this.lf2MemoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
			this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
			this.logoPictureBox.Name = "logoPictureBox";
			this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
			this.logoPictureBox.Size = new System.Drawing.Size(391, 285);
			this.logoPictureBox.TabIndex = 12;
			this.logoPictureBox.TabStop = false;
			// 
			// productNameLabel
			// 
			this.productNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.productNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.productNameLabel.Location = new System.Drawing.Point(403, 0);
			this.productNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.productNameLabel.MaximumSize = new System.Drawing.Size(0, 17);
			this.productNameLabel.Name = "productNameLabel";
			this.productNameLabel.Size = new System.Drawing.Size(270, 17);
			this.productNameLabel.TabIndex = 19;
			this.productNameLabel.Text = "Product Name";
			this.productNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// productVersionLabel
			// 
			this.productVersionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.productVersionLabel.Location = new System.Drawing.Point(403, 64);
			this.productVersionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.productVersionLabel.MaximumSize = new System.Drawing.Size(0, 17);
			this.productVersionLabel.Name = "productVersionLabel";
			this.productVersionLabel.Size = new System.Drawing.Size(270, 17);
			this.productVersionLabel.TabIndex = 0;
			this.productVersionLabel.Text = "Product Version";
			this.productVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// copyrightLabel
			// 
			this.copyrightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.copyrightLabel.Location = new System.Drawing.Point(403, 96);
			this.copyrightLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.copyrightLabel.MaximumSize = new System.Drawing.Size(0, 17);
			this.copyrightLabel.Name = "copyrightLabel";
			this.copyrightLabel.Size = new System.Drawing.Size(270, 17);
			this.copyrightLabel.TabIndex = 21;
			this.copyrightLabel.Text = "Copyright";
			this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// companyNameLabel
			// 
			this.companyNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.companyNameLabel.Location = new System.Drawing.Point(403, 128);
			this.companyNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
			this.companyNameLabel.MaximumSize = new System.Drawing.Size(0, 17);
			this.companyNameLabel.Name = "companyNameLabel";
			this.companyNameLabel.Size = new System.Drawing.Size(270, 17);
			this.companyNameLabel.TabIndex = 22;
			this.companyNameLabel.Text = "Company Name";
			this.companyNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.descriptionTextBox.Location = new System.Drawing.Point(403, 163);
			this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.descriptionTextBox.Multiline = true;
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.ReadOnly = true;
			this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.descriptionTextBox.Size = new System.Drawing.Size(270, 125);
			this.descriptionTextBox.TabIndex = 23;
			this.descriptionTextBox.TabStop = false;
			this.descriptionTextBox.Text = "Description";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(319, 298);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 22);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "OK";
			// 
			// AboutForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.okButton;
			this.ClientSize = new System.Drawing.Size(694, 341);
			this.Controls.Add(this.tableLayoutPanel);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.Padding = new System.Windows.Forms.Padding(9);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About Product";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.Label lf2MemoryLabel;

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.PictureBox logoPictureBox;
		private System.Windows.Forms.Label productNameLabel;
		private System.Windows.Forms.Label productVersionLabel;
		private System.Windows.Forms.Label copyrightLabel;
		private System.Windows.Forms.Label companyNameLabel;
		private System.Windows.Forms.TextBox descriptionTextBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label assemblyVersionLabel;
	}
}
