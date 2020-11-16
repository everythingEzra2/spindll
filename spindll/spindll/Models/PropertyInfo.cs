using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using spindll.Enum;

namespace spindll.Models {

	class PropertyInfo {
		public string PropertyName;
		public string InputDataType;
		public DataTypeEnum SystemDataType;
		public string OutputDataType; 
		public List<string> CustomAnnotations;

		public List<PropertyInfo> TypeArgs;

		public bool HasTypeArgs { get => TypeArgs != null && TypeArgs.Count > 0;}

		public PropertyInfo(System.Reflection.PropertyInfo property) {
			PropertyName = property.Name;
			InputDataType = property.PropertyType.Name;

			CustomAnnotations = ExtractCustomSpindllAttributes(property.CustomAttributes.ToList());

			TypeArgs = property.PropertyType.GenericTypeArguments.Select(ta => new PropertyInfo(ta)).ToList();
		}

		public PropertyInfo(System.Type property) {
			InputDataType = property.Name;

			CustomAnnotations = ExtractCustomSpindllAttributes(property.CustomAttributes.ToList());

			TypeArgs = property.GenericTypeArguments.Select(ta => new PropertyInfo(ta)).ToList();
		}

		public static List<string> ExtractCustomSpindllAttributes(List<CustomAttributeData> customAttributes) {
			if (!customAttributes.Any())
				return new List<string>();

			var propTypeName = "SpindllProp";
			var spindllAttribs = customAttributes
				.Where(a => a.AttributeType.FullName.Contains(propTypeName))
				.ToList();

			return spindllAttribs
				.Select(sa => sa.ConstructorArguments.FirstOrDefault().Value.ToString())
				.ToList();
		}
	}
	

}