using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using spindll.annotations;

namespace spindll.annotations
{
	public static class Annotations 
	{
		[Obsolete("use function with name param")]
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

		public static List<string> ExtractCustomSpindllAttributes(string annotationName, List<CustomAttributeData> customAttributes) {
			if (!customAttributes.Any())
				return new List<string>();

			// var propTypeName = "SpindllProp";
			var spindllAttribs = customAttributes
				.Where(a => a.AttributeType.FullName.Contains(annotationName))
				.ToList();

			return spindllAttribs
				.Select(sa => sa.ConstructorArguments.FirstOrDefault().Value.ToString())
				.ToList();
		}
	}
}