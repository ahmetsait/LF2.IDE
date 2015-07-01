using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ScintillaNET;

namespace LF2.IDE
{
	public sealed class Settings
	{
		public static Settings Current = new Settings();

		public static readonly string SettingsDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\LF2.IDE",
			SettingsPath = SettingsDir + "\\Settings.xml";

		public string lfPath = "lf2.exe",
			encryptionKey = "odBearBecauseHeIsVeryGoodSiuHungIsAGo",
			decryptionKey = "odBearBecauseHeIsVeryGoodSiuHungIsAGo",
			dataUtil = null,
			lang = "default";

		public LineWrappingMode lineWrappingMode = LineWrappingMode.None;

		public int tabWidth = 3,
			textureZoom = 10;

		public bool showWhiteSpaces = false,
			showEndOfLineChars = false,
			reversePaint = true,
			checkUpdatesAuto = true,
			autoComplete = true;

		public List<string> recentFileHistory = new List<string>(8),
			activePlugins = new List<string>();

		public void Reload()
		{
			if (File.Exists(SettingsPath))
			{
				using (FileStream settings = new FileStream(SettingsPath, FileMode.Open, FileAccess.Read))
				{
					XmlSerializer xs = new XmlSerializer(typeof(Settings));
					Current = (Settings)xs.Deserialize(settings);
					settings.Close();
				}
			}
		}

		public void Save()
		{
			if (!Directory.Exists(SettingsDir))
				Directory.CreateDirectory(SettingsDir);
			using (FileStream settings = new FileStream(SettingsPath, FileMode.Create, FileAccess.Write))
			{
				XmlSerializer xs = new XmlSerializer(typeof(Settings));
				xs.Serialize(settings, Current);
				settings.Close();
			}
		}
	}
}
