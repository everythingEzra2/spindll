using System;
using System.Reflection;

namespace spindll.logic 
{
    public static class ClassInspector
    {
        public static void LoadDll(string filePath)
        {
            var DLL = Assembly.LoadFile(filePath);

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
