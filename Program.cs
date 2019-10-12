using System;
using spindll.logic;

namespace spindll
{
    class Program
    {
        static void Main(string[] args)
        {
			ClassInspector.LoadDll(@"D:\_repo\f5saver\f5saver.api\F5Saver.Common\bin\Debug\netstandard2.0\F5Saver.Common.dll");
			// ClassInspector.LoadDll(@"/home/myr/_repo/f5saver/f5saver.api/F5Saver.Common/bin/Debug/netstandard2.0/F5Saver.Common.dll");
        }
    }
}
