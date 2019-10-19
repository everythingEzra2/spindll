using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace spindll.Logic 
{
    public static class ClassInspector
    {
        public static Type[] LoadDll(string filePath)
        {
            var DLL = Assembly.LoadFile(filePath);

			// var _type = DLL.GetType("F5Saver.Common.Models.Question");
			// var _type2 = DLL.GetType("F5Saver.Common.Models.User");

			var _types = DLL.GetTypes();
			// var obj = DLL.GetExportedTypes();

			return _types;
        }
    }
}