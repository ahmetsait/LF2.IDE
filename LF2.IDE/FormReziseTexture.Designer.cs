/*
 * Created by SharpDevelop.
 * User: mediha.killi
 * Date: 25.07.2013
 * Time: 23:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LF2.IDE
{
	partial class FormReziseTexture
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
			this.textBox_Width = new System.Windows.Forms.TextBox();
			this.label_Width = new System.Windows.Forms.Label();
			this.textBox_Height = new System.Windows.Forms.TextBox();
			this.label_Height = new System.Windows.Forms.Label();
			this.button_OK = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBox_Width
			// 
			this.textBox_Width.Location = new System.Drawing.Point(59, 12);
			this.textBox_Width.Name = "textBox_Width";
			this.textBox_Width.Size = new System.Drawing.Size(109, 20);
			this.textBox_Width.TabIndex = 0;
			this.textBox_Width.Validating += new System.ComponentModel.CancelEventHandler(this.WBoxValidating);
			// 
			// label_Width
			// 
			this.label_Width.AutoSize = true;
			this.label_Width.Location = new System.Drawing.Point(12, 15);
			this.label_Width.Name = "label_Width";
			this.label_Width.Size = new System.Drawing.Size(41, 13);
			this.label_Width.TabIndex = 1;
			this.label_Width.Text = "Width :";
			// 
			// textBox_Height
			// 
			this.textBox_Height.Location = new System.Drawing.Point(62, 38);
			this.textBox_Height.Name = "textBox_Height";
			this.textBox_Height.Size = new System.Drawing.Size(106, 20);
			this.textBox_Height.TabIndex = 1;
			this.textBox_Height.Validating += new System.ComponentModel.CancelEventHandler(this.HBoxValidating);
			// 
			// label_Height
			// 
			this.label_Height.AutoSize = true;
			this.label_Height.Location = new System.Drawing.Point(12, 41);
			this.label_Height.Name = "label_Height";
			this.label_Height.Size = new System.Drawing.Size(44, 13);
			this.label_Height.TabIndex = 1;
			this.label_Height.Text = "Height :";
			// 
			// button_OK
			// 
			this.button_OK.Location = new System.Drawing.Point(12, 64);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(75, 23);
			this.button_OK.TabIndex = 2;
			this.button_OK.TabStop = false;
			this.button_OK.Text = "OK";
			this.button_OK.UseVisualStyleBackColor = true;
			this.button_OK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// button_Cancel
			// 
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.Location = new System.Drawing.Point(93, 64);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 2;
			this.button_Cancel.TabStop = false;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// FormReziseTexture
			// 
			this.AcceptButton = this.button_OK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(180, 99);
			this.ControlBox = false;
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.label_Height);
			this.Controls.Add(this.label_Width);
			this.Controls.Add(this.textBox_Height);
			this.Controls.Add(this.textBox_Width);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormReziseTexture";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Resize Texture";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public System.Windows.Forms.TextBox textBox_Width;
		public System.Windows.Forms.TextBox textBox_Height;
		public System.Windows.Forms.Button button_Cancel;
		public System.Windows.Forms.Button button_OK;
		public System.Windows.Forms.Label label_Height;
		public System.Windows.Forms.Label label_Width;
	}
}
