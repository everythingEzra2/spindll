using System;
using System.Collections.Generic;
using System.Linq;
using spindll.logic;

namespace spindll
{
    class Program
    {
        static void Main(string[] args)
        {
			// ClassInspector.LoadDll(@"D:\_repo\f5saver\f5saver.api\F5Saver.Common\bin\Debug\netstandard2.0\F5Saver.Common.dll");
			var types = ClassInspector.LoadDll(@"/home/myr/_repo/f5saver/f5saver.api/F5Saver.Common/bin/Debug/netstandard2.0/F5Saver.Common.dll").ToList()S;

			var models = extractModels(types);
        }

		static List<string> extractModels(List<Type> types) 
		{

			var typeList = types.ToList();
			typeList.ForEach(t => {
				var models 
			});
		}
    }
}

namespace spindll.Models {
	class EnumInfo {
		public string EnumName;
		public Dictionary<int, string> Values;
	}

	class ModelInfo {
		public ModelInfo() {}
		public ModelInfo(Type type) {
			ModelName = type.FullName;

			var properties = type.GetProperties();
			
		}
		public string ModelName;
		public List<PropertyInfo> Properties;
	}

	class PropertyInfo {
		public string PropertyName;
		public string DataType;
	}
}
