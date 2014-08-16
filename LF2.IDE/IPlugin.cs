using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using CSScriptLibrary;

namespace PluginManager
{
	public class Plugger<T>
	{
		private Dictionary<string, T> plugs = new Dictionary<string, T>(8);

		public T this[string key]
		{
			get { return plugs[key]; }
		}

		public void PlugOn(string directory, string filter = "*.cs", SearchOption searchOption = SearchOption.TopDirectoryOnly)
		{
			Type interfaceType = typeof(T);

			foreach (string file in Directory.GetFiles(directory, filter, searchOption))
			{
				CSScript.Evaluator.LoadFile<IPlugin>(file);
			}
		}

		public void PlugIn(string file)
		{
			Type interfaceType = typeof(T);

			foreach (Type type in Assembly.LoadFile(Path.GetFullPath(file)).GetTypes())
			{
				if (interfaceType.IsAssignableFrom(type) && interfaceType != type)
				{
					T instance = (T)Activator.CreateInstance(type);
					plugs.Add(type.Name, instance);
				}
			}
		}

		public void PlugOut(string key)
		{
			plugs.Remove(key);
		}

		public void PlugOff()
		{
			plugs.Clear();
		}
	}
}

interface IPlugin
{
	string Name { get; }
	string Author { get; }
	string IdeVersion { get; }
	string Description { get; }
	string Warning { get; }
	string Category { get; }
	string Web { get; }

	void Register();
	void Unregister();
}