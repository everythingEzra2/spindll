using System;
using System.Reflection;

namespace spindll.logic 
{
    public static class ClassInspector
    {
        public static void LoadDll(string filePath)
        {
            var DLL = Assembly.LoadFile(filePath);

			// var t = DLL.GetType("Question");
			// var activator = Activator.CreateInstance(t, false, false);

			var name = DLL.FullName;
			var modules = DLL.Modules;
			var common = DLL.GetModules();
			var com = common.Length;

			// var dllmod = DLL.DefinedTypes;

			var commonModule = modules.First();
			// var types = commonModule.Assembly.DefinedTypes;

			var _type = DLL.GetType("F5Saver.Common.Models.Question");
			var _type2 = DLL.GetType("F5Saver.Common.Models.User");

			// var _types = DLL.GetTypes();
			var obj = DLL.GetExportedTypes();

            foreach(Type type in DLL.GetExportedTypes())
            {
                dynamic c = Activator.CreateInstance(type);
                c.Output(@"Hello");
            }

            Console.ReadLine();
        }
    }
}
