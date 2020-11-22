using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.Loader;
using System.IO;

namespace spindll.Logic 
{
    public static class ClassInspector
    {
        public static Type[] LoadDll(string filePath)
        {
			var c = new PluginLoadContext();
			var fileBytes = File.ReadAllBytes(filePath);
			var stream = new MemoryStream(fileBytes);
			var DLL = c.LoadFromStream(stream);

			var _types = DLL.GetTypes();

			c.Unload();

			return _types;
        }
    }

	public class PluginLoadContext : AssemblyLoadContext
	{
		public PluginLoadContext() : base(isCollectible: true)
		{
		}
	}
}
