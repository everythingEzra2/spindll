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

		public PropertyInfo(System.Reflection.PropertyInfo property) {
			PropertyName = property.Name;
			InputDataType = property.PropertyType.Name;
		}
	}
	
}