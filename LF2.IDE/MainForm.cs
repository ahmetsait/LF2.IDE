﻿using CSScriptLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LF2.IDE
{
	public partial class MainForm : Form
	{
		[DllImport("InstantDataModifier.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		public static extern void InstantDataModifier(string data, int procId, int objId, int datType);

		string[] args;
		public static Stopwatch stopWatch;

		public MainForm(string[] args)
		{
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(this.UnhandledError);
			InitializeComponent();

			this.args = args;

			try
			{
				Settings.Current.Reload();
				showAllCharsToolStripButton.Checked = Settings.Current.showEndOfLineChars || Settings.Current.showWhiteSpaces;
				checkUpdatesAutoToolStripMenuItem.Checked = Settings.Current.checkUpdatesAuto;
				if (Settings.Current.lineWrappingMode == ScintillaNET.LineWrappingMode.None)
				{
					textWrapToolStripButton.Checked = false;
					textWrapToolStripButton.Image = imageList.Images[0];
				}
				else if (Settings.Current.lineWrappingMode == ScintillaNET.LineWrappingMode.Word)
				{
					textWrapToolStripButton.Checked = true;
					textWrapToolStripButton.Image = imageList.Images[0];
				}
				else if (Settings.Current.lineWrappingMode == ScintillaNET.LineWrappingMode.Char)
				{
					textWrapToolStripButton.Checked = true;
					textWrapToolStripButton.Image = imageList.Images[1];
				}
				textWrapToolStripButton.ToolTipText = "Wrap: " + Settings.Current.lineWrappingMode.ToString();
				syntaxLanguageToolStripComboBox.Text = Settings.Current.lang;
				tabWidthToolStripComboBox.Text = Settings.Current.tabWidth.ToString();
				updateHistory();
			}
			catch (Exception ex)
			{
				formEventLog = new FormEventLog();
				formEventLog.Error(ex, "Settings Designer Error");
			}

			bool isLoaded = false;

			if (!File.Exists(Program.dockingPath))
			{
				if (formEventLog == null)
					formEventLog = new FormEventLog();
				formTag = new FormTag(this);
				formFrame = new FormFrame(this);
				formShape = new FormShape(this);
				solutionExplorer = new SolutionExplorer(this);
				media = new MediaPlayer();
			}
			else
			{
				dockPanel.LoadFromXml(Program.dockingPath, new WeifenLuo.WinFormsUI.Docking.DeserializeDockContent(DockingDeserializer));
				isLoaded = true;
			}

			try
			{
				OpenWithImage(args, false);
			}
			catch (Exception ex)
			{
				formEventLog.Error(ex, "Startup Error");
			}

			if (!isLoaded)
			{
				formTag.Show(dockPanel);
				formFrame.Show(dockPanel);
				formShape.Show(dockPanel);
				media.Show(dockPanel);
				formEventLog.Show(dockPanel);
				solutionExplorer.Show(dockPanel);
				formTag.AutoHidePortion = 450;
				formFrame.AutoHidePortion = 300;
				formShape.AutoHidePortion = 300;
				media.AutoHidePortion = 300;
				formEventLog.AutoHidePortion = 250;
				solutionExplorer.AutoHidePortion = 300;
			}

			formEventLog.Log("Initialized: " + stopWatch.Elapsed, false);
			stopWatch.Restart();
		}

		public FormTag formTag;
		public FormFrame formFrame;
		public FormShape formShape;
		public SolutionExplorer solutionExplorer;
		public MediaPlayer media;
		public FormEventLog formEventLog;

		public static Plugger<Plugin> Plugins = new Plugger<Plugin>();
		public static bool PluginLock = true;

		private void MainForm_Load(object sender, EventArgs e)
		{
			if (Settings.Current.checkUpdatesAuto)
			{
				backgroundWorker_UpdateChecker.RunWorkerAsync(false);
				checkForUpdatesToolStripMenuItem.Text = "Checking for Updates...";
			}

			if (Directory.Exists(Program.templateDir))
				foreach (string file in Directory.GetFiles(Program.templateDir))
					newToolStripButton.DropDownItems.Add(new ToolStripMenuItem(Path.GetFileNameWithoutExtension(file), null, TemplateClicked, Path.GetFullPath(file)));

			if (ActiveDocument != null)
			{
				lastActiveFrame = (lastActiveDoc = ActiveDocument).frames;
				if (lastActiveFrame != null && lastActiveFrame.Length > 0)
				{
					formTag.numericUpDown_ImageIndex.Maximum =
					formFrame.numericUoDown_imageIndex.Maximum =
					formShape.numericUpDown_ImageIndex.Maximum = lastActiveFrame.Length - 1;
					formTag.drawBox.Image =
					formFrame.drawBox.Image =
					formShape.drawBox.Image = lastActiveFrame[0];
				}
				ActiveDocument.Scintilla.Focus();
				this.Activate();
			}
			if (File.Exists(Settings.Current.lfPath))
			{
				solutionExplorer.refreshToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
				solutionExplorer.PopulateTreeView(solutionExplorer.DestinationFolder);
				formTag.stopWatch.Start();
				formTag.button_RefreshOpointViewer.Text = "...";
				formTag.backgroundWorker_Refresh.RunWorkerAsync();
			}

			//CSScript.Evaluator.CompilerSettings.AssemblyReferences.AddRange(from a in Assembly.GetExecutingAssembly().GetReferencedAssemblies() select a.FullName);
			//CSScript.Evaluator.CompilerSettings.Unsafe = true;

			formEventLog.Log("MainForm Loaded: " + stopWatch.Elapsed, false);
			stopWatch.Reset();

			backgroundWorker_Util.RunWorkerAsync();
			backgroundWorker_Plugin.RunWorkerAsync();
		}

		public WeifenLuo.WinFormsUI.Docking.DockPanel DockPanel { get { return dockPanel; } }

		public void implementSettings()
		{
			foreach (DocumentForm df in dockPanel.Documents)
			{
				df.Scintilla.EndOfLine.IsVisible = Settings.Current.showEndOfLineChars;
				df.Scintilla.LineWrapping.Mode = Settings.Current.lineWrappingMode;
				df.Scintilla.Whitespace.Mode = Settings.Current.showWhiteSpaces ? ScintillaNET.WhitespaceMode.VisibleAlways : ScintillaNET.WhitespaceMode.Invisible;

				switch (Path.GetExtension(df.TabText.TrimEnd(' ', '*')))
				{
					case ".dat":
						df.SetLanguage("dat");
						break;
					case ".txt":
						df.SetLanguage("txt");
						break;
					case ".as":
						df.SetLanguage("as");
						break;
					case ".xml":
						df.SetLanguage("xml");
						break;
					case ".html":
					case ".htm":
						df.SetLanguage("html");
						break;
					case ".cs":
						df.SetLanguage("cs");
						break;
					default:
						df.SetLanguage(Settings.Current.lang);
						break;
				}
			}
		}

		readonly string felPersist = typeof(FormEventLog).FullName,
			ftPersist = typeof(FormTag).FullName,
			ffPersist = typeof(FormFrame).FullName,
			fsPersist = typeof(FormShape).FullName,
			sePersist = typeof(SolutionExplorer).FullName,
			mpPersist = typeof(MediaPlayer).FullName;

		WeifenLuo.WinFormsUI.Docking.DockContent DockingDeserializer(string persistString)
		{
			if (persistString == felPersist)
				return formEventLog = new FormEventLog();
			else if (persistString == ftPersist)
				return formTag = new FormTag(this);
			else if (persistString == ffPersist)
				return formFrame = new FormFrame(this);
			else if (persistString == fsPersist)
				return formShape = new FormShape(this);
			else if (persistString == sePersist)
				return solutionExplorer = new SolutionExplorer(this);
			else if (persistString == mpPersist)
				return media = new MediaPlayer();
			else return null;
		}

		public DocumentForm ActiveDocument { get { return dockPanel.ActiveDocument as DocumentForm; } }

		private void UnhandledError(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			formEventLog.Error(e.Exception, "UNHANDLED ERROR");
		}

		private void TemplateClicked(object sender, EventArgs e)
		{
			ToolStripMenuItem item = sender as ToolStripMenuItem;
			string file = item.Name;
			if (!File.Exists(file))
				newToolStripButton.DropDownItems.Remove(item);
			else
				OpenWithText(File.ReadAllText(file, Encoding.Default), Path.GetFileName(file));
		}

		private void openRecent(object sender, EventArgs e)
		{
			string fns = (sender as ToolStripMenuItem).Text;
			if (!File.Exists(fns))
			{
				MessageBox.Show("File '" + fns + "' not exists in target path", Program.Title);
				Settings.Current.recentFileHistory.Remove(fns);
				updateHistory();
			}
			else
				Open(fns, true);
		}

		private void argsTransClick(object sender, EventArgs e)
		{
			Bitmap img = (sender as ToolStripMenuItem).OwnerItem.Tag as Bitmap;
			FormTransparencyTools ft = new FormTransparencyTools(img, (sender as ToolStripMenuItem).OwnerItem.Text, this);
			ft.Show(this);
		}

		private void argsPixClick(object sender, EventArgs e)
		{
			Bitmap img = (sender as ToolStripMenuItem).OwnerItem.Tag as Bitmap;
			FormImageSaver ft = new FormImageSaver(img, (sender as ToolStripMenuItem).OwnerItem.Text, true, this);
			ft.ShowDialog(this);
		}

		private void argsMirClick(object sender, EventArgs e)
		{
			Bitmap img = (sender as ToolStripMenuItem).OwnerItem.Tag as Bitmap;
			FormSpriteMirrorer ft = new FormSpriteMirrorer(img, (sender as ToolStripMenuItem).OwnerItem.Text, this);
			ft.ShowDialog(this);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MainForm_Closing(object sender, FormClosingEventArgs e)
		{
			foreach (DocumentForm doc in dockPanel.Documents)
			{
				if (doc.Scintilla.Modified)
				{
					// Prompt if not saved
					string message = String.Format(
						CultureInfo.CurrentCulture,
						"The data in the {0} file has changed.{1}{2}Do you want to save the changes?",
						doc.TabText.TrimEnd(' ', '*'),
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
						e.Cancel = !doc.Save();
						return;
					}
				}
			}
		}

		private void selectalltoolStripButton_Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				ActiveDocument.Scintilla.Selection.SelectAll();
		}

		private void cutToolStripButton_Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				ActiveDocument.Scintilla.Clipboard.Cut();
		}

		private void copyToolStripButton_Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				ActiveDocument.Scintilla.Clipboard.Copy();
		}

		private void pasteToolStripButton_Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				ActiveDocument.Scintilla.Selection.Text = Clipboard.GetText(TextDataFormat.Text);
		}

		private void undotoolStripButton_Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				ActiveDocument.Scintilla.UndoRedo.Undo();
		}

		private void redotoolStripButton_Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				ActiveDocument.Scintilla.UndoRedo.Redo();
		}

		public void addToHistory(string file)
		{
			if (!Settings.Current.recentFileHistory.Contains(file))
				Settings.Current.recentFileHistory.Add(file);
			else
			{
				Settings.Current.recentFileHistory.Remove(file);
				Settings.Current.recentFileHistory.Add(file);
			}
			if (Settings.Current.recentFileHistory.Count > 30)
				for (int i = Settings.Current.recentFileHistory.Count - 30; i >= 0; i--)
					Settings.Current.recentFileHistory.RemoveAt(i);
		}

		public void updateHistory()
		{
			openRecentToolStripMenuItem.DropDownItems.Clear();
			foreach (string rf in Settings.Current.recentFileHistory)
			{
				ToolStripMenuItem tsmi = new ToolStripMenuItem(rf);
				tsmi.Click += new EventHandler(openRecent);
				openRecentToolStripMenuItem.DropDownItems.Insert(0, tsmi);
			}
			openRecentToolStripMenuItem.Enabled = clearRecentHistoryToolStripMenuItem.Enabled = openRecentToolStripMenuItem.DropDownItems.Count > 0;
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			if (openFileDialogData.ShowDialog() == DialogResult.OK)
				Open(openFileDialogData.FileNames);
			updateHistory();
		}

		FormWindowState lastWindowState = FormWindowState.Maximized;

		public void NewInstance(ReadOnlyCollection<string> argmeter)
		{
			OpenWithImage(argmeter, true);
			this.Activate();
			this.WindowState = lastWindowState;
		}

		private void saveToolStripButton_Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null && (ActiveDocument.Scintilla.Modified || string.IsNullOrEmpty(ActiveDocument.FilePath)))
				ActiveDocument.Save();
		}

		private void erasetoolStripButton_Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
			{
				ActiveDocument.Scintilla.Selection.SelectAll();
				ActiveDocument.Scintilla.Selection.Text = "";
			}
		}

		private void saveasToolStripButton_Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				ActiveDocument.SaveAs();
		}

		void FindtoolStripButton_Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
			{
				ActiveDocument.Scintilla.FindReplace.ShowFind();
			}
		}

		void CutToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			cutToolStripButton.PerformClick();
		}

		void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			copyToolStripButton.PerformClick();
		}

		void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			pasteToolStripButton.PerformClick();
		}

		void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			saveAllToolStripButton.PerformClick();
		}

		void SettingsToolStripButton_Click(object sender, EventArgs e)
		{
			FormSettings fs = new FormSettings();
			if (fs.ShowDialog() == DialogResult.OK)
				implementSettings();
		}

		void NewToolStripButton_Click(object sender, EventArgs e)
		{
			OpenWithText("", null);
		}

		void saveAllToolStripButton_Click(object sender, EventArgs e)
		{
			foreach (DocumentForm doc in dockPanel.Documents)
			{
				if (doc.Scintilla.Modified)
					doc.Save();
			}
		}

		void ReplaceToolStripButton_Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
			{
				ActiveDocument.Scintilla.FindReplace.ShowReplace();
			}
		}

		void StartToolStripMenuItemClick(object sender, EventArgs e)
		{
			string lfpath = Settings.Current.lfPath;
			if (File.Exists(lfpath))
			{
				ProcessStartInfo psi = new ProcessStartInfo();
				psi.FileName = Settings.Current.lfPath;
				psi.WorkingDirectory = Path.GetDirectoryName(Settings.Current.lfPath);
				Process.Start(psi);
			}
		}

		public static Process lfProc = null;

		void CloseAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach (Process prc in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Settings.Current.lfPath)))
			{
				if (!prc.HasExited)
					prc.Kill();
			}
		}

		void CloseToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
			{
				ActiveDocument.Close();
			}
		}

		void MainFormForm_Closed(object sender, FormClosedEventArgs e)
		{
			Settings.Current.Save();
			try
			{
				dockPanel.SaveAsXml(Program.dockingPath);
			}
			catch (Exception ex)
			{
				formEventLog.Error(ex, "Xml Serialization Error");
			}
			try
			{
				foreach (string plugin in Settings.Current.activePlugins)
					Plugins[plugin].OnExit(e.CloseReason);
			}
			catch (Exception ex)
			{
				formEventLog.Error(ex, "Plugin Manager Error");
			}
		}

		public Bitmap[] lastActiveFrame;
		public DocumentForm lastActiveDoc;

		void DockPanelActiveDocumentChanged(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
			{
				toolStripIncrementalSearcher.Scintilla = ActiveDocument.Scintilla;
				if (ActiveDocument.frames != null)
				{
					lastActiveDoc = ActiveDocument;
					lastActiveFrame = lastActiveDoc.frames;
					formTag.numericUpDown_ImageIndex.Maximum =
					formFrame.numericUoDown_imageIndex.Maximum =
					formShape.numericUpDown_ImageIndex.Maximum = lastActiveFrame.Length - 1;
					formTag.numericUpDown_ImageIndex.Value = lastActiveDoc.frameIndexTag;
					formFrame.numericUoDown_imageIndex.Value = lastActiveDoc.frameIndexFrame;
					formShape.numericUpDown_ImageIndex.Value = lastActiveDoc.frameIndexShape;
					formTag.drawBox.Image = lastActiveFrame[lastActiveDoc.frameIndexTag];
					formFrame.drawBox.Image = lastActiveFrame[lastActiveDoc.frameIndexFrame];
					formShape.drawBox.Image = lastActiveFrame[lastActiveDoc.frameIndexShape];
				}
			}
			else
				toolStripIncrementalSearcher.Scintilla = null;
		}

		void ToolStripLabel1Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
			{
				if (frameIndexToolStripTextBox.Text.Trim() == "") return;
				ScintillaNET.Range rng = ActiveDocument.Scintilla.FindReplace.Find(new Regex("(<frame>) (" + frameIndexToolStripTextBox.Text + " )"));
				if (rng != null)
				{
					ActiveDocument.Scintilla.GoTo.Position(rng.Start);
					ActiveDocument.Scintilla.GoTo.Line(ActiveDocument.Scintilla.Lines.Current.Number + 1);
					ActiveDocument.Activate();
					ActiveDocument.Scintilla.Focus();
				}
			}
		}

		void ToolStripLabel2Click(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
			{
				if (frameCaptionToolStripComboBox.Text.Trim() == "") return;
				ScintillaNET.Range rng = ActiveDocument.Scintilla.FindReplace.Find(new Regex(@"(<frame>) ([1-3][0-9][0-9]|[1-9][0-9]|[0-9]) (" + frameCaptionToolStripComboBox.Text + ")(\n)")) == null ? ActiveDocument.Scintilla.FindReplace.Find(new Regex(@"(<frame>) ([1-3][0-9][0-9]|[1-9][0-9]|[0-9]) (" + frameCaptionToolStripComboBox.Text + ")(\r\n)")) : ActiveDocument.Scintilla.FindReplace.Find(new Regex(@"(<frame>) ([1-3][0-9][0-9]|[1-9][0-9]|[0-9]) (" + frameCaptionToolStripComboBox.Text + ")(\n)"));
				if (rng != null)
				{
					ActiveDocument.Scintilla.GoTo.Position(rng.Start);
					ActiveDocument.Scintilla.GoTo.Line(ActiveDocument.Scintilla.Lines.Current.Number + 1);
					ActiveDocument.Activate();
					ActiveDocument.Scintilla.Focus();
				}
			}
		}

		void ToolStripButtonlnClick(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
			{
				int o;
				if (!int.TryParse(lineNumberToolStripTextBox.Text, out o)) return;
				ActiveDocument.Scintilla.GoTo.Line(o - 1);
				ActiveDocument.Activate();
				ActiveDocument.Scintilla.Focus();
			}
		}

		void LanguageSettingsToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach (DocumentForm pth in dockPanel.Documents)
			{
				if (pth.FilePath == Program.langPath)
				{
					pth.Activate();
					pth.Focus();
					return;
				}
			}
			if (File.Exists(Program.langPath))
				Open(Program.langPath, true);
		}

		void DummyToolStripButtonClick(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
			{
				string wew = ActiveDocument.Scintilla.Text;
				int ff = wew.LastIndexOf("<frame> 399 ");
				if (ff < 0) return;
				int fg = wew.IndexOf("<frame_end>", ff);
				if (fg < 0) return;
				wew = wew.Substring(ff, (fg + 11) - ff);
				ActiveDocument.Scintilla.Selection.Text = wew;
			}
		}

		void ToolStripButtonReopenClick(object sender, EventArgs e)
		{
			if (ActiveDocument == null || string.IsNullOrEmpty(ActiveDocument.FilePath)) return;

			string fns = ActiveDocument.FilePath;
			if (!File.Exists(fns))
			{
				MessageBox.Show("File '" + fns + "' not exists in target path", Program.Title);
				ActiveDocument.Scintilla.Modified = true;
				updateHistory();
			}
			else if (ActiveDocument.Scintilla.Modified)
			{
				string message = String.Format(
					"The data in the {0} file has changed.{1}{2}Do you want to discard the changes?",
					ActiveDocument.TabText.TrimEnd(' ', '*'),
					Environment.NewLine,
					Environment.NewLine);

				DialogResult dr = MessageBox.Show(this, message, Program.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
				if (dr == DialogResult.No)
					return;
				else
					Reopen(ActiveDocument, fns);
			}
			else
				Reopen(ActiveDocument, fns);
		}

		void Reopen(DocumentForm doc, string file)
		{
			if (file.EndsWith(".dat"))
			{
				doc.Scintilla.Text = "";
				doc.Scintilla.AppendText(LF2DataUtil.Decrypt(file));
				doc.Scintilla.UndoRedo.EmptyUndoBuffer();
				doc.Scintilla.Modified = false;
			}
			else
			{
				doc.Scintilla.Text = "";
				doc.Scintilla.AppendText(File.ReadAllText(file, Encoding.Default));
				doc.Scintilla.UndoRedo.EmptyUndoBuffer();
				doc.Scintilla.Modified = false;
				doc.Show(dockPanel);
			}
		}

		void AboutToolStripButtonClick(object sender, EventArgs e)
		{
			AboutForm af = new AboutForm();
			af.ShowDialog();
		}

		void ShowTagWindowToolStripMenuItemClick(object sender, EventArgs e)
		{
			formTag.Show();
		}

		void ShowFrameWindowToolStripMenuItemClick(object sender, EventArgs e)
		{
			formFrame.Show();
		}

		void ShowShapeWindowToolStripMenuItemClick(object sender, EventArgs e)
		{
			formShape.Show();
		}

		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}

		void SelectAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				ActiveDocument.Scintilla.Selection.SelectAll();
		}

		void SearchToolStripMenuItemClick(object sender, EventArgs e)
		{
			Process.Start(Program.webPage);
		}

		void AlgorithmToolStripMenuItemClick(object sender, EventArgs e)
		{
			OpenWithText(Properties.Resources.DataAlgorithm, "DataAlgorithm.cs");
		}

		void ToolStripComboBox2TextChanged(object sender, EventArgs e)
		{
			Settings.Current.lang = syntaxLanguageToolStripComboBox.Text == "" ? "default" : syntaxLanguageToolStripComboBox.Text;
			implementSettings();
			dockPanel.Refresh();
		}

		void ToolStripButtonzinClick(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				ActiveDocument.Scintilla.Zoom = Math.Min(Math.Max(-7, ActiveDocument.Scintilla.Zoom + 1), 20);
		}

		void ToolStripButtonzoutClick(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				ActiveDocument.Scintilla.Zoom = Math.Min(Math.Max(-7, ActiveDocument.Scintilla.Zoom - 1), 20);
		}

		void ToolStripButtonwwClick(object sender, EventArgs e)
		{
			if (Settings.Current.lineWrappingMode == ScintillaNET.LineWrappingMode.None)
			{
				Settings.Current.lineWrappingMode = ScintillaNET.LineWrappingMode.Word;
				textWrapToolStripButton.Checked = true;
				textWrapToolStripButton.Image = imageList.Images[0];
			}
			else if (Settings.Current.lineWrappingMode == ScintillaNET.LineWrappingMode.Word)
			{
				Settings.Current.lineWrappingMode = ScintillaNET.LineWrappingMode.Char;
				textWrapToolStripButton.Checked = true;
				textWrapToolStripButton.Image = imageList.Images[1];
			}
			else if (Settings.Current.lineWrappingMode == ScintillaNET.LineWrappingMode.Char)
			{
				Settings.Current.lineWrappingMode = ScintillaNET.LineWrappingMode.None;
				textWrapToolStripButton.Checked = false;
				textWrapToolStripButton.Image = imageList.Images[0];
			}
			textWrapToolStripButton.ToolTipText = "Wrap: " + Settings.Current.lineWrappingMode.ToString();
			implementSettings();
		}

		void ToolStripButtoneolClick(object sender, EventArgs e)
		{
			Settings.Current.showEndOfLineChars = Settings.Current.showWhiteSpaces = showAllCharsToolStripButton.Checked;
			implementSettings();
		}

		void ToolStripButtonFClick(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
			{
				foreach (ScintillaNET.Line linear in ActiveDocument.Scintilla.Lines)
				{
					if (linear.IsFoldPoint && linear.FoldExpanded && linear.Text.Contains(toolStripComboBoxF.Text))
					{
						linear.ToggleFoldExpanded();
					}
				}
			}
		}

		void ToolStripButtonUFClick(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
			{
				foreach (ScintillaNET.Line linear in ActiveDocument.Scintilla.Lines)
				{
					if (linear.IsFoldPoint && !linear.FoldExpanded && linear.Text.Contains(toolStripComboBoxUF.Text))
					{
						linear.ToggleFoldExpanded();
					}
				}
			}
		}

		//[StructLayout(LayoutKind.Sequential)]
		//public struct Rect
		//{
		//	public int left;
		//	public int top;
		//	public int right;
		//	public int bottom;
		//}

		//[DllImport("user32.dll")]
		//public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);

		//public Bitmap CaptureWindow(IntPtr windowHandle)
		//{
		//	Rect rect = new Rect();
		//	GetWindowRect(windowHandle, ref rect);

		//	int width = rect.right - rect.left;
		//	int height = rect.bottom - rect.top;

		//	Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppRgb);
		//	using (Graphics g = Graphics.FromImage(bmp))
		//		g.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);

		//	return bmp;
		//}

		//public string AviRecordDir { get { return Path.GetDirectoryName(Settings.Current.lfPath) + "\\records"; } }

		void DebugToolStripMenuItemClick(object sender, EventArgs e)
		{
			string lfpath = Settings.Current.lfPath;
			if (File.Exists(lfpath))
			{
				ProcessStartInfo psi = new ProcessStartInfo();
				psi.FileName = Settings.Current.lfPath;
				psi.WorkingDirectory = Path.GetDirectoryName(Settings.Current.lfPath);
				lfProc = Process.Start(psi);
				lfProc.PriorityClass = ProcessPriorityClass.High;
				FormWindowState fws = this.WindowState;
				this.WindowState = FormWindowState.Minimized;
				//record = new Queue<Bitmap>(1024);
				//backgroundWorkerLF2Recorder.RunWorkerAsync(lfProc);
				//backgroundWorkerRecordStreamer.RunWorkerAsync(AviRecordDir);
				while (!lfProc.HasExited)
					Application.DoEvents();
				//backgroundWorkerLF2Recorder.CancelAsync();
				//backgroundWorkerRecordStreamer.CancelAsync();
				this.WindowState = fws;
				lfProc = null;
			}
		}

		//		volatile Queue<Bitmap> record;

		void RestartToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach (Process prc in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Settings.Current.lfPath)))
			{
				if (!prc.HasExited)
				{
					prc.Kill();
					ProcessStartInfo psi = new ProcessStartInfo(Settings.Current.lfPath);
					psi.WorkingDirectory = Path.GetDirectoryName(Settings.Current.lfPath);
					Process.Start(psi);
				}
			}
		}

		void ShowMediaWindowToolStripMenuItemClick(object sender, EventArgs e)
		{
			media.Show();
		}

		void ShowSolutionWindowToolStripMenuItemClick(object sender, EventArgs e)
		{
			solutionExplorer.Show();
		}

		void ToolStripButtonQuickCheckedChanged(object sender, EventArgs e)
		{
			toolStripIncrementalSearcher.Enabled = quickToolStripButton.Checked;
		}

		void TabStripComboBoxTextChanged(object sender, EventArgs e)
		{
			try
			{
				Settings.Current.tabWidth = int.Parse(tabWidthToolStripComboBox.Text);
				implementSettings();
			}
			catch { }
		}

		void ErrorLogToolStripMenuItemClick(object sender, EventArgs e)
		{
			formEventLog.Show();
		}

		void ToolStripButton4CheckStateChanged(object sender, EventArgs e)
		{
			//if (toolStripButton4.Checked)
			//{
			//	toolStrip2.BringToFront();
			//	toolStrip3.BringToFront();
			//	dockPanel.BringToFront();
			//}
			jumpToToolStrip.Visible = jumpToToolStripButton.Checked;
		}

		void TransparencyToolToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (openFileDialog_Image.ShowDialog() == DialogResult.OK)
			{
				Bitmap img = (Bitmap)Image.FromFile(openFileDialog_Image.FileName);
				FormTransparencyTools ft = new FormTransparencyTools(img, openFileDialog_Image.FileName, this);
				ft.Show(this);
			}
		}

		void ResetCurrentZoomToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				ActiveDocument.Scintilla.Zoom = 0;
		}

		void ResetAllDocumentsZoomingToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach (DocumentForm doc in dockPanel.Documents)
			{
				doc.Scintilla.Zoom = 0;
			}
		}

		void PixelFormatterToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (openFileDialog_Image.ShowDialog() == DialogResult.OK)
			{
				Bitmap img = (Bitmap)Image.FromFile(openFileDialog_Image.FileName);
				FormImageSaver ft = new FormImageSaver(img, openFileDialog_Image.FileName, true, this);
				ft.ShowDialog(this);
			}
		}

		void DownloadPageToolStripMenuItemClick(object sender, EventArgs e)
		{
			Process.Start(Program.downloadPage);
		}

		void ToolStripButtonExportToHtmlClick(object sender, EventArgs e)
		{
			if (ActiveDocument != null)
				OpenWithText(ActiveDocument.Scintilla.ExportHtml(), Path.GetFileNameWithoutExtension(ActiveDocument.TabText.TrimEnd(' ', '*')) + ".html");
		}

		void RefreshAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (Settings.Current.lfPath == null || !File.Exists(Settings.Current.lfPath))
			{
				FormSettings f = new FormSettings();
			re:
				if (f.ShowDialog(this) == DialogResult.OK)
				{
					if (Settings.Current.lfPath == null || !File.Exists(Settings.Current.lfPath))
						goto re;
				}
				else
					return;
			}
			try
			{
				foreach (DocumentForm doc in dockPanel.Documents)
				{
					if (doc.TabText.TrimEnd(' ', '*').EndsWith(".dat"))
					{
						doc.ParseFiles(Path.GetDirectoryName(Settings.Current.lfPath));
						doc.ParseFrames();
					}
				}
				lastActiveFrame = ActiveDocument.frames;
				if (lastActiveFrame != null && lastActiveFrame.Length > 0)
				{
					formTag.numericUpDown_ImageIndex.Maximum =
					formFrame.numericUoDown_imageIndex.Maximum =
					formShape.numericUpDown_ImageIndex.Maximum = lastActiveFrame.Length - 1;
					formTag.numericUpDown_ImageIndex.Value = formFrame.numericUoDown_imageIndex.Value = formShape.numericUpDown_ImageIndex.Value = 0;
					formTag.drawBox.Image =
					formFrame.drawBox.Image =
					formShape.drawBox.Image = lastActiveFrame[0];
				}
			}
			catch (Exception ex)
			{
				formEventLog.Error(ex, "Parsing Error");
			}
		}

		void RefreshCurrentToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (Settings.Current.lfPath == null || !File.Exists(Settings.Current.lfPath))
			{
				FormSettings f = new FormSettings();
			re:
				if (f.ShowDialog(this) == DialogResult.OK)
				{
					if (Settings.Current.lfPath == null || !File.Exists(Settings.Current.lfPath))
						goto re;
				}
				else
					return;
			}
			try
			{
				ActiveDocument.ParseFiles(Path.GetDirectoryName(Settings.Current.lfPath));
				ActiveDocument.ParseFrames();
				lastActiveFrame = ActiveDocument.frames;
				if (lastActiveFrame != null && lastActiveFrame.Length > 0)
				{
					formTag.numericUpDown_ImageIndex.Maximum =
					formFrame.numericUoDown_imageIndex.Maximum =
					formShape.numericUpDown_ImageIndex.Maximum = lastActiveFrame.Length - 1;
					formTag.numericUpDown_ImageIndex.Value = formFrame.numericUoDown_imageIndex.Value = formShape.numericUpDown_ImageIndex.Value = 0;
					formTag.drawBox.Image =
					formFrame.drawBox.Image =
					formShape.drawBox.Image = lastActiveFrame[0];
				}
			}
			catch (Exception ex)
			{
				formEventLog.Error(ex, "Parsing Error");
			}
		}

		void MainFormResizeEnd(object sender, EventArgs e)
		{
			if (this.WindowState != FormWindowState.Minimized) lastWindowState = this.WindowState;
		}

		//void BackgroundWorkerLF2RecorderDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		//{
		//	Process lfp = (Process)e.Argument;
		//	while (lfp.MainWindowHandle == IntPtr.Zero)
		//		if (backgroundWorkerLF2Recorder.CancellationPending)
		//		{
		//			e.Cancel = true;
		//			return;
		//		}
		//	while (lfp.MainWindowHandle != IntPtr.Zero)
		//		record.Enqueue(CaptureWindow(lfp.MainWindowHandle));
		//}

		//void BackgroundWorkerLF2RecorderRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		//{

		//}

		//static Random randomizer = new Random();

		//void BackgroundWorkerRecordStreamerDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		//{
		//	string file = e.Argument + "record" + randomizer.Next() + ".avi";
		//	AviUtils.AviManager avi = new AviUtils.AviManager(file, true);
		//}

		//void BackgroundWorkerRecordStreamerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		//{

		//}

		void SpriteMirrorerToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (openFileDialog_Image.ShowDialog() == DialogResult.OK)
			{
				Bitmap img = (Bitmap)Image.FromFile(openFileDialog_Image.FileName);
				FormSpriteMirrorer fm = new FormSpriteMirrorer(img, openFileDialog_Image.FileName, this);
				fm.Show(this);
			}
		}

		void MainFormDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
				e.Effect = DragDropEffects.Copy;
			else
				e.Effect = DragDropEffects.None;
		}

		public void MainFormDragDrop(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(DataFormats.FileDrop))
				return;

			OpenWithImage(e.Data.GetData(DataFormats.FileDrop) as string[], false);
		}

		public void Open(string file, bool updateHistory)
		{
			if (file.EndsWith(".dat"))
			{
				DocumentForm doc = new DocumentForm(this);
				doc.Scintilla.AppendText(LF2DataUtil.Decrypt(file));
				doc.Scintilla.UndoRedo.EmptyUndoBuffer();
				doc.Scintilla.Modified = false;
				doc.TabText = Path.GetFileName(file);
				doc.FilePath = file;
				doc.Show(dockPanel);
			}
			else
			{
				DocumentForm doc = new DocumentForm(this);
				doc.Scintilla.AppendText(File.ReadAllText(file, Encoding.Default));
				doc.Scintilla.UndoRedo.EmptyUndoBuffer();
				doc.Scintilla.Modified = false;
				doc.TabText = Path.GetFileName(file);
				doc.FilePath = file;
				doc.Show(dockPanel);
			}
			addToHistory(file);
			if (updateHistory) this.updateHistory();
		}

		public void Open(IEnumerable<string> files)
		{
			foreach (string file in files)
				Open(file, false);

			updateHistory();
		}

		public bool OpenWithImage(string file, bool updateHistory)
		{
			bool arg = false;
			if (file.EndsWith(".dat"))
			{
				DocumentForm doc = new DocumentForm(this);
				doc.Scintilla.AppendText(LF2DataUtil.Decrypt(file));
				doc.Scintilla.UndoRedo.EmptyUndoBuffer();
				doc.Scintilla.Modified = false;
				doc.TabText = Path.GetFileName(file);
				doc.FilePath = file;
				doc.Show(dockPanel);
			}
			else if (file.EndsWith(".bmp") || file.EndsWith(".dib") || file.EndsWith(".png") || file.EndsWith(".jpg") || file.EndsWith(".jpeg") || file.EndsWith(".jpe") || file.EndsWith(".jfif") || file.EndsWith(".gif") || file.EndsWith(".emf") || file.EndsWith(".tif") || file.EndsWith(".tiff") || file.EndsWith(".wmf"))
			{
				Bitmap img = (Bitmap)Image.FromFile(file);
				img.Tag = Path.GetFileName(file);
				ToolStripMenuItem item = new ToolStripMenuItem(img.Tag as string),
				trans = new ToolStripMenuItem("Make Transparent"),
				pix = new ToolStripMenuItem("Change Pixel Format"),
				mir = new ToolStripMenuItem("Make Mirrored");
				item.Tag = img;
				trans.Click += new EventHandler(argsTransClick);
				pix.Click += new EventHandler(argsPixClick);
				mir.Click += new EventHandler(argsMirClick);
				item.DropDownItems.Add(trans);
				item.DropDownItems.Add(pix);
				item.DropDownItems.Add(mir);
				argsToolStripMenuItem.DropDownItems.Add(item);
				arg = true;
			}
			else
			{
				DocumentForm doc = new DocumentForm(this);
				doc.Scintilla.AppendText(File.ReadAllText(file, Encoding.Default));
				doc.Scintilla.UndoRedo.EmptyUndoBuffer();
				doc.Scintilla.Modified = false;
				doc.TabText = Path.GetFileName(file);
				doc.FilePath = file;
				doc.Show(dockPanel);
			}
			if (!arg) addToHistory(file);
			if (updateHistory) this.updateHistory();
			return arg;
		}

		public void OpenWithImage(IEnumerable<string> files, bool skipFirst)
		{
			bool arg = false;
			IEnumerator<string> filer = files.GetEnumerator();

			if (skipFirst) filer.MoveNext();

			while (filer.MoveNext())
				arg |= OpenWithImage(filer.Current, false);

			updateHistory();

			this.Activate();
			if (arg) argsToolStripMenuItem.ShowDropDown();
		}

		public void OpenWithText(string text, string title)
		{
			DocumentForm doc = new DocumentForm(this);
			doc.Scintilla.AppendText(text);
			doc.Scintilla.UndoRedo.EmptyUndoBuffer();
			doc.Scintilla.Modified = false;
			if (title != null) doc.TabText = title;
			doc.FilePath = null;
			doc.Show(dockPanel);
		}

		void CheckForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (backgroundWorker_UpdateChecker.IsBusy)
				MessageBox.Show("Still checking for updates...");
			else
				backgroundWorker_UpdateChecker.RunWorkerAsync(true);

			checkForUpdatesToolStripMenuItem.Text = "&Checking for Updates...";
		}

		public enum UpdateState : byte
		{
			None,
			Available,
			Developer
		}

		public UpdateState CheckForUpdates()
		{
			WebClient wc = new WebClient();
			Match match = Regex.Match(wc.DownloadString(Program.webPage), "{#UpdateCheckerArea:(.*):#}");
			Version version = new Version(match.Groups[1].Value), current = new Version(AboutForm.AssemblyVersion);

			if (current > version)
				return UpdateState.Developer;
			else if (current == version)
				return UpdateState.None;
			else
				return UpdateState.Available;
		}

		abstract class Notificable
		{
			public bool notify;
		}

		class UpdateInfo : Notificable
		{
			public UpdateState update;

			public UpdateInfo(bool notify, UpdateState update)
			{
				this.notify = notify;
				this.update = update;
			}
		}

		class UpdateError : Notificable
		{
			public Exception ex;

			public UpdateError(bool notify, Exception ex)
			{
				this.notify = notify;
				this.ex = ex;
			}
		}

		void BackgroundUpdater_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				e.Result = new UpdateInfo((bool)e.Argument, CheckForUpdates());
			}
			catch (Exception ex)
			{
				e.Result = new UpdateError((bool)e.Argument, ex);
			}
		}

		void BackgroundUpdater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			checkForUpdatesToolStripMenuItem.Text = "&Check for Updates";
			bool notify = ((Notificable)e.Result).notify;
			if (e.Result is UpdateError)
			{
				Exception error = ((UpdateError)e.Result).ex;
				if (notify)
					formEventLog.Error(error, "Update Checking Error");
				else
					formEventLog.Log("Update check failed", false);
			}
			else if (e.Result is UpdateInfo)
			{
				UpdateInfo updateInfo = (UpdateInfo)e.Result;
				if (updateInfo.update == UpdateState.None)
				{
					if (updateInfo.notify)
						MessageBox.Show(this, "I believe you have the lastest version :)", "Update Checker");
					else
						formEventLog.Log("No update detected", false);
				}
				else
				{
					if (updateInfo.update == UpdateState.Available)
					{
						formEventLog.Log(Program.webPage + "\r\n" + Program.downloadPage, "Update Found!", true);
						formEventLog.Show();
					}
					else
					{
						if (updateInfo.notify)
							MessageBox.Show(this, "Somehow, it appears that your current version is even higher than the lastest one", "Update Checker");
						else
							formEventLog.Log("Somehow, it appears that your current version is even higher than the lastest one", "Update Checker", false);
					}
				}
			}
		}

		void CheckUpdatesAutoToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			Settings.Current.checkUpdatesAuto = checkUpdatesAutoToolStripMenuItem.Checked;
		}

		private void clearRecentHistoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Settings.Current.recentFileHistory.Clear();
			updateHistory();
		}

		private void toolStripComboBoxF_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				e.SuppressKeyPress = e.Handled = true;
				toolStripButtonF.PerformClick();
			}
		}

		private void toolStripComboBoxUF_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				e.SuppressKeyPress = e.Handled = true;
				toolStripButtonUF.PerformClick();
			}
		}

		private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				e.SuppressKeyPress = e.Handled = true;
				frmaeIndexToolStripButton.PerformClick();
			}
		}

		private void toolStripComboBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				e.SuppressKeyPress = e.Handled = true;
				frameCaptionToolStripButton.PerformClick();
			}
		}

		private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
			{
				e.SuppressKeyPress = e.Handled = true;
				lineNumberToolStripButton.PerformClick();
			}
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			if (argsToolStripMenuItem.DropDownItems.Count != 0)
				argsToolStripMenuItem.ShowDropDown();
		}

		private void backgroundWorker_Util_DoWork(object sender, DoWorkEventArgs e)
		{
			Stopwatch sw = Stopwatch.StartNew();
			if (Directory.Exists(Program.utilDir))
			{
				UtilManager.GetUtils(Program.utilDir);
				formEventLog.Log("Data Utils Loaded: " + sw.Elapsed, false);
			}
			sw.Reset();
		}

		private void backgroundWorker_Util_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			UtilManager.UtilLock = false;
		}

		private void backgroundWorker_Plugin_DoWork(object sender, DoWorkEventArgs e)
		{
			Stopwatch sw = Stopwatch.StartNew();
			if (Directory.Exists(Program.plugDir))
			{
				Plugins.PlugOn(Program.plugDir);
				formEventLog.Log("Plugins Loaded: " + sw.Elapsed, false);
			}
			sw.Reset();
		}

		private void backgroundWorker_Plugin_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			PluginLock = false;
			try
			{
				foreach (string plugin in Settings.Current.activePlugins)
					try
					{
						Plugins[plugin].Register();
					}
					catch (Exception ex)
					{
						formEventLog.Error(ex, "[" + plugin + "] : Plugin Registration Error");
					}
			}
			catch (Exception ex)
			{
				formEventLog.Error(ex, "Plugin-List Registration Error");
			}
		}
	}
}
