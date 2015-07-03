﻿using ScintillaNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace LF2.IDE
{
	public sealed partial class DocumentForm : DockContent
	{
		private string _filePath;
		private bool _issaved;

		public List<SpriteSheet> spriteList = new List<SpriteSheet>(0);
		public Bitmap[] frames;
		public int frameIndexTag;
		public int frameIndexFrame;
		public int frameIndexShape;

		private MainForm mainForm;


		public string FilePath
		{
			get { return _filePath; }
			set { _filePath = value; }
		}


		public bool Issaved
		{
			get { return _issaved; }
			set { _issaved = value; }
		}


		public Scintilla Scintilla
		{
			get
			{
				return scintilla;
			}
		}


		#region Methods

		private void AddOrRemoveAsteric()
		{
			if (Scintilla.Modified)
			{
				if (!TabText.EndsWith(" *"))
					TabText += " *";
			}
			else
			{
				if (TabText.EndsWith(" *"))
					TabText = TabText.Substring(0, TabText.Length - 2);
			}
		}


		private void DocumentForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Scintilla.Modified)
			{
				// Prompt if not saved
				string message = String.Format(
					CultureInfo.CurrentCulture,
					"The data in the {0} file has changed.{1}{2}Do you want to save the changes?",
					TabText.TrimEnd(' ', '*'),
					Environment.NewLine,
					Environment.NewLine);

				DialogResult dr = MessageBox.Show(this, message, Program.Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
				if (dr == DialogResult.Cancel)
				{
					// Stop closing
					e.Cancel = true;
					return;
				}
				else if (dr == DialogResult.Yes)
				{
					// Try to save before closing
					e.Cancel = !Save();
					return;
				}
			}

			// Close as normal
		}


		public bool ExportAsHtml()
		{
			using (SaveFileDialog dialog = new SaveFileDialog())
			{
				string fileName = (Text.EndsWith(" *") ? Text.Substring(0, Text.Length - 2) : Text);
				dialog.Filter = "HTML Files (*.html;*.htm)|*.html;*.htm|All Files (*.*)|*.*";
				dialog.FileName = fileName + ".html";
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					scintilla.Lexing.Colorize(); // Make sure the document is current
					using (StreamWriter sw = new StreamWriter(dialog.FileName))
						scintilla.ExportHtml(sw, fileName, false);

					return true;
				}
			}

			return false;
		}


		public bool Save()
		{
			if (String.IsNullOrEmpty(_filePath))
				return SaveAs();

			return Save(_filePath);
		}

		public bool Save(string filePath)
		{
			if (filePath.EndsWith(".dat"))
				LF2DataUtil.Encrypt(Scintilla.Text, filePath);
			else
				File.WriteAllText(filePath, Scintilla.Text, Encoding.Default);

			scintilla.Modified = false;
			return true;
		}

		public bool SaveAs()
		{
			string tabText = TabText.TrimEnd(' ', '*');
			if (!string.IsNullOrEmpty(_filePath))
			{
				saveFileDialog.FileName = Path.GetFileName(_filePath);
				saveFileDialog.InitialDirectory = Path.GetDirectoryName(_filePath);
			}
			else
			{
				saveFileDialog.FileName = tabText;
			}
			switch (Path.GetExtension(tabText))
			{
				case ".dat":
					saveFileDialog.FilterIndex = 2;
					break;
				case ".txt":
					saveFileDialog.FilterIndex = 3;
					break;
				case ".as":
					saveFileDialog.FilterIndex = 4;
					break;
				case ".xml":
					saveFileDialog.FilterIndex = 5;
					break;
				case ".html":
				case ".htm":
					saveFileDialog.FilterIndex = 6;
					break;
				case ".cs":
					saveFileDialog.FilterIndex = 7;
					break;
				default:
					saveFileDialog.FilterIndex = 1;
					break;
			}
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				ToolTipText = _filePath = saveFileDialog.FileName;
				TabText = Path.GetFileName(_filePath);

				switch (Path.GetExtension(TabText))
				{
					case ".dat":
						SetLanguage("dat");
						break;
					case ".txt":
						SetLanguage("txt");
						break;
					case ".as":
						SetLanguage("as");
						break;
					case ".xml":
						SetLanguage("xml");
						break;
					case ".html":
					case ".htm":
						SetLanguage("html");
						break;
					case ".cs":
						SetLanguage("cs");
						break;
					default:
						SetLanguage(Settings.Current.lang);
						break;
				}

				return Save(_filePath);
			}

			return false;
		}


		private void scintilla_ModifiedChanged(object sender, EventArgs e)
		{
			AddOrRemoveAsteric();
		}


		public DocumentForm(MainForm main)
		{
			mainForm = main;
			InitializeComponent();
		}

		void DocumentFormActivated(object sender, EventArgs e)
		{
			Scintilla.Focus();
		}

		void DocumentFormLoad(object sender, EventArgs e)
		{
			Scintilla.EndOfLine.IsVisible = Settings.Current.showEndOfLineChars;
			Scintilla.LineWrapping.Mode = Settings.Current.lineWrappingMode;
			Scintilla.Whitespace.Mode = Settings.Current.showWhiteSpaces ? ScintillaNET.WhitespaceMode.VisibleAlways : ScintillaNET.WhitespaceMode.Invisible;
			ToolTipText = _filePath == null ? TabText : _filePath;
			switch (Path.GetExtension(TabText))
			{
				case ".dat":
					SetLanguage("dat");
					break;
				case ".txt":
					SetLanguage("txt");
					break;
				case ".as":
					SetLanguage("as");
					break;
				case ".xml":
					SetLanguage("xml");
					break;
				case ".html":
				case ".htm":
					SetLanguage("html");
					break;
				case ".cs":
					SetLanguage("cs");
					break;
				default:
					SetLanguage(Settings.Current.lang);
					break;
			}
			scintilla.NativeInterface.SendMessageDirect(2516, true);
			SetMarginAuto();

			if (Settings.Current.lfPath == null || !File.Exists(Settings.Current.lfPath))
				return;

			if (TabText.TrimEnd(' ', '*').EndsWith(".dat"))
				try
				{
					ParseFiles(Path.GetDirectoryName(Settings.Current.lfPath));
					ParseFrames();
				}
				catch (Exception ex)
				{
					mainForm.formEventLog.Error(ex, "Parsing Error");
				}
		}

		public void ParseFiles(string lfdir)
		{
			spriteList.Clear();
			string dat = scintilla.Text;
			int begin = dat.IndexOf("<bmp_begin>"), end = dat.IndexOf("<bmp_end>", begin + 11);
			if (begin < 0 || end < 0) return;
			string script = dat.Substring(begin + 11, end - begin);
			MatchCollection matches = Regex.Matches(script, SpriteSheet.regexPattern);
			if (matches.Count < 1) return;
			for (int i = 0; i < matches.Count; i++)
			{
				string path = lfdir + "\\" + matches[i].Groups[3].Value.Trim();
				Bitmap img = (Bitmap)Image.FromFile(path);
				img.Tag = Path.GetFileName(path);
				int si = int.Parse(matches[i].Groups[1].Value.Trim()),
					ei = int.Parse(matches[i].Groups[2].Value.Trim()),
					w = int.Parse(matches[i].Groups[4].Value.Trim()),
					h = int.Parse(matches[i].Groups[5].Value.Trim()),
					r = int.Parse(matches[i].Groups[6].Value.Trim()),
					c = int.Parse(matches[i].Groups[7].Value.Trim());
				SpriteSheet fm = new SpriteSheet(si, ei, img.Tag as string, img, w, h, c, r);
				spriteList.Add(fm);
			}
		}

		public void ParseFrames()
		{
			int top = 1;
			foreach (SpriteSheet fm in spriteList)
				if (fm.endIndex + 1 > top) top = fm.endIndex + 1;

			frames = new Bitmap[top];
			for (int i = 0; i < top; i++)
				frames[i] = null;

			for (int i = 0; i < spriteList.Count; i++)
			{
				SpriteSheet fm = spriteList[i];
				int k = fm.startIndex;
				for (int r = 0; r < fm.row; r++)
				{
					for (int c = 0; c < fm.col && k <= fm.endIndex; c++, k++)
					{
						Bitmap btm = new Bitmap(fm.w, fm.h, PixelFormat.Format32bppRgb);
						using (Graphics g = Graphics.FromImage(btm))
							g.DrawImage(fm.sprite, new Rectangle(0, 0, fm.w, fm.h), new Rectangle(c * (fm.w + 1), r * (fm.h + 1), fm.w, fm.h), GraphicsUnit.Pixel);
						frames[k] = btm;
					}
				}
			}
		}

		bool auto = false, smart = false;

		public void SetLanguage(string language)
		{
			language = language.ToLowerInvariant();
			{
				this.Scintilla.Snippets.List.Clear();
				this.Scintilla.AutoComplete.List.Clear();
				this.Scintilla.ConfigurationManager.Language = "default";
				this.Scintilla.ConfigurationManager.Language = language;
				if (language == "dat")
				{
					Scintilla.Indentation.UseTabs = false;
					Scintilla.Indentation.TabWidth = Settings.Current.tabWidth;
					Scintilla.EndOfLine.Mode = EndOfLineMode.LF;
					this.Icon = Properties.Resources.DocumentDAT;
					auto = true;
					smart = true;
				}
				else if (language == "txt")
				{
					Scintilla.Indentation.UseTabs = false;
					Scintilla.Indentation.TabWidth = Settings.Current.tabWidth;
					Scintilla.EndOfLine.Mode = EndOfLineMode.Crlf;
					this.Icon = Properties.Resources.DocumentDAT;
					auto = true;
					smart = true;
				}
				else if (language == "as")
				{
					Scintilla.Indentation.UseTabs = true;
					Scintilla.Indentation.TabWidth = 4;
					Scintilla.EndOfLine.Mode = EndOfLineMode.Crlf;
					this.Icon = Properties.Resources.DocumentAS;
					auto = false;
					smart = true;
				}
				else if (language == "cs")
				{
					Scintilla.Indentation.UseTabs = true;
					Scintilla.Indentation.TabWidth = 4;
					Scintilla.EndOfLine.Mode = EndOfLineMode.Crlf;
					this.Icon = Properties.Resources.DocumentCS;
					auto = false;
					smart = true;
				}
				else if (language == "xml" || language == "html")
				{
					Scintilla.Indentation.UseTabs = false;
					Scintilla.Indentation.TabWidth = 2;
					Scintilla.EndOfLine.Mode = EndOfLineMode.Crlf;
					this.Icon = Properties.Resources.DocumentXML;
					auto = false;
					smart = true;
				}
				else
				{
					Scintilla.Indentation.UseTabs = false;
					Scintilla.Indentation.TabWidth = Settings.Current.tabWidth;
					Scintilla.EndOfLine.Mode = EndOfLineMode.Crlf;
					this.Icon = Properties.Resources.Document;
					auto = false;
					smart = false;
				}
				Scintilla.AutoComplete.List.Sort();
			}
		}

		void ScintillaCharAdded(object sender, CharAddedEventArgs e)
		{
			if (auto && Settings.Current.autoComplete)
			{
				if (scintilla.Lexing.WordChars.Contains(e.Ch.ToString()))
				{
					string word = scintilla.GetWordFromPosition(scintilla.Caret.Position);
					foreach (string str in scintilla.AutoComplete.List)
					{
						try { if (str[0] > word[0]) break; }
						catch { }

						if (str.StartsWith(word))
						{
							scintilla.AutoComplete.Show();
							break;
						}
					}
				}
			}
			if (Scintilla.EndOfLine.EolString[Scintilla.EndOfLine.EolString.Length - 1] == e.Ch && smart)
			{
				scintilla.Lines.Current.Indentation = scintilla.Lines.Current.Previous.Indentation;
				scintilla.CurrentPos = scintilla.Lines.Current.IndentPosition;
			}
		}

		void ScintillaKeyPress(object sender, KeyPressEventArgs e)
		{
			if (auto && Settings.Current.autoComplete)
				if (e.KeyChar == ':' || e.KeyChar == '>')
				{
					e.Handled = true;
					scintilla.AutoComplete.Accept();
					scintilla.Selection.Text = e.KeyChar.ToString();
				}
		}

		void ScintillaZoomChanged(object sender, EventArgs e)
		{
			SetMarginAuto();
		}

		void ScintillaTextChanged(object sender, EventArgs e)
		{
			SetMarginAuto();
		}

		public void SetMarginAuto()
		{
			int last_measure_lines = -1;
			int lines = scintilla.Lines.Count;
			if (lines != last_measure_lines)
			{
				last_measure_lines = lines;
				Scintilla.Margins[0].Width = TextRenderer.MeasureText(lines.ToString(), Scintilla.Font).Width + Scintilla.Zoom * 3;
			}
		}

		#endregion Methods
	}
}
