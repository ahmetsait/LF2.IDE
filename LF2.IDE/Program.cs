using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.VisualBasic.ApplicationServices;

namespace LF2.IDE
{
	internal sealed class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				MainForm.stopWatch = System.Diagnostics.Stopwatch.StartNew();
				Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(true);
				using (mainForm = new MainForm(args))
					SingleInstanceApplication.Run(mainForm, NewInstanceHandler);
			}
			catch (Exception ex)
			{
				File.AppendAllText(exeDir + "\\FatalError.log", ex.ToString() + "\r\n\r\n", Encoding.Default);
				Process.Start(exeDir + "\\FatalError.log");
			}
			finally
			{
				MainForm.stopWatch.Reset();
			}
		}

		public static MainForm mainForm = null;

		public static void NewInstanceHandler(object sender, StartupNextInstanceEventArgs e)
		{
			e.BringToForeground = true;
			mainForm.NewInstance(e.CommandLine);
		}

		public class SingleInstanceApplication : WindowsFormsApplicationBase
		{
			private SingleInstanceApplication()
			{
				base.IsSingleInstance = true;
			}

			public static void Run(Form form, StartupNextInstanceEventHandler startupHandler)
			{
				SingleInstanceApplication app = new SingleInstanceApplication();
				app.MainForm = form;
				app.StartupNextInstance += startupHandler;
				app.Run(Environment.GetCommandLineArgs());
			}
		}

		public static readonly string exeDir = Path.GetDirectoryName(Application.ExecutablePath);

		public static readonly string langPath = exeDir + "\\data.lang.xml";
		public static readonly string dockingPath = exeDir + "\\docking.xml";
		public static readonly string utilDir = exeDir + "\\DataUtils";
		public static readonly string templateDir = exeDir + "\\Templates";
		public const string downloadPage = "http://www.mediafire.com/download/h0pb7ielao88bd1/LF2IDE.rar";
		public const string supportPage = "http://www.lf-empire.de/forum/showthread.php?tid=9064";

		public const string Title = "LF2.IDE";
		public const string Version = "1.6.1";
	}
}
