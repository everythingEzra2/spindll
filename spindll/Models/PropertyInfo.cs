namespace spindll.Models {

	class PropertyInfo {
		public string PropertyName;
		public string DataType;

		public PropertyInfo(System.Reflection.PropertyInfo property) {
			PropertyName = property.Name;
			DataType = property.PropertyType.Name;
		}
	}
	
}