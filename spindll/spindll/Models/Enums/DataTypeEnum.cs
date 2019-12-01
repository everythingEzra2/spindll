using System;

namespace spindll.Enum {

	public enum DataTypeEnum {
		// Default
		Unknown,

		// Primatives
		Bool,
		Int,
		Long,
		String,
		DateTime,

		// List/Array/Enumerations
		List,
		Array,

		// Class use
		Class,

		// No key, map directly
		DirectMap
	}
}