using System;
using System.Collections.Generic;
using System.Linq;
using spindll.Enum;

namespace spindll.Models {

	class PropertyInfo {
		public string PropertyName;
		public string InputDataType;
		public DataTypeEnum SystemDataType;
		public string OutputDataType; 

		public List<PropertyInfo> TypeArgs;

		public bool HasTypeArgs { get => TypeArgs != null && TypeArgs.Count > 0;}

		public PropertyInfo(System.Reflection.PropertyInfo property) {
			PropertyName = property.Name;
			InputDataType = property.PropertyType.Name;

			TypeArgs = property.PropertyType.GenericTypeArguments.Select(ta => new PropertyInfo(ta)).ToList();
		}

		public PropertyInfo(System.Type property) {
			InputDataType = property.Name;

			TypeArgs = property.GenericTypeArguments.Select(ta => new PropertyInfo(ta)).ToList();
		}
	}
	
}