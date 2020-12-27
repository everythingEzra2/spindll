using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using spindll.annotations;

namespace spindll.Models {

	class ModelInfo {
		public string ModelName;
		public string InheritanceString;
		public List<string> CustomAnnotations = new List<string>(); 
		public List<PropertyInfo> Properties = new List<PropertyInfo>();

		public ModelInfo(Type type) {
			ModelName = type.FullName.Split('.').ToList().LastOrDefault(); ;

			InheritanceString = Annotations.ExtractCustomSpindllAttributes("SpindllInheritance", type.CustomAttributes.ToList()).FirstOrDefault();
			CustomAnnotations = Annotations.ExtractCustomSpindllAttributes("SpindllProp", type.CustomAttributes.ToList());

			var properties = type.GetProperties().ToList();
			
			properties.ForEach(p => {
				var prop = new PropertyInfo(p);
				Properties.Add(prop);
			});
		}
	}

}