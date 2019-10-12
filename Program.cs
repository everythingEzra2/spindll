using System;
using System.Collections.Generic;
using System.Linq;
using spindll.Logic;
using spindll.Models;

namespace spindll
{
    class Program
    {
        static void Main(string[] args)
        {
			var types = ClassInspector.LoadDll(@"D:\_repo\f5saver\f5saver.api\F5Saver.Common\bin\Debug\netstandard2.0\F5Saver.Common.dll").ToList();
			// var types = ClassInspector.LoadDll(@"/home/myr/_repo/f5saver/f5saver.api/F5Saver.Common/bin/Debug/netstandard2.0/F5Saver.Common.dll").ToList();

			var models = extractModels(types);
        }

		static List<ModelInfo> extractModels(List<Type> types) 
		{
			var modelList = new List<ModelInfo>();
			var typeList = types.Where(t => t.BaseType?.FullName != "System.Enum").ToList();

			typeList.ForEach(t => {
				var model = new ModelInfo(t);
				modelList.Add(model);
			});

			return modelList;
		}
    }
}

// namespace spindll.Models {
// 	class EnumInfo {
// 		public string EnumName;
// 		public Dictionary<int, string> Values;
// 	}

// 	class ModelInfo {
// 		public string ModelName;
// 		public List<PropertyInfo> Properties = new List<PropertyInfo>();

// 		public ModelInfo(Type type) {
// 			ModelName = type.FullName;

// 			var properties = type.GetProperties().ToList();
			
// 			properties.ForEach(p => {
// 				var prop = new PropertyInfo(p);
// 				Properties.Add(prop);
// 			});
// 		}
// 	}

// 	class PropertyInfo {
// 		public string PropertyName;
// 		public string DataType;

// 		public PropertyInfo(System.Reflection.PropertyInfo property) {
// 			PropertyName = property.Name;
// 			DataType = property.PropertyType.Name;
// 		}
// 	}
// }
