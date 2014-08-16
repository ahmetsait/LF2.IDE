using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace LF2.IDE
{
	public static class UtilManager
	{
		public static Dictionary<string, IDataUtil> Utils = GetUtils(Program.utilDir);

		public static IDataUtil ActiveUtil { get { return Utils[Settings.Default.dataUtil]; } }

		public static Dictionary<string, IDataUtil> GetUtils(string dir)
		{
			string[] files;
			if (!Directory.Exists(dir) || (files = Directory.GetFiles(dir, "*.dll")).Length == 0)
				return null;
			Dictionary<string, IDataUtil> result = new Dictionary<string, IDataUtil>(1);
			Type interfaceType = typeof(IDataUtil);
			foreach (string file in files)
			{
				foreach (Type type in Assembly.LoadFile(Path.GetFullPath(file)).GetTypes())
				{
					if (interfaceType.IsAssignableFrom(type) && interfaceType != type)
					{
						IDataUtil instance = (IDataUtil)Activator.CreateInstance(type);
						result[instance.ToString()] = instance;
					}
				}
			}
			return result;
		}
	}
}
