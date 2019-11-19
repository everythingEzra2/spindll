using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace spindll.Models {

	class ModelInfo {
		public string ModelName;
		public List<PropertyInfo> Properties = new List<PropertyInfo>();

		public ModelInfo(Type type) {
			ModelName = type.FullName.Split('.').ToList().LastOrDefault(); ;

			var properties = type.GetProperties().ToList();
			
			properties.ForEach(p => {
				var prop = new PropertyInfo(p);
				Properties.Add(prop);
			});
		}
	}

}