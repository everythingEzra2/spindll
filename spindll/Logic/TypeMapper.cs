using System.Collections.Generic;
using spindll.Enum;

namespace spindll.Logic {

	public static class TypeMapper {
		

	}

	public class TypeMap {
		public LanguageEnum SourceLanguage;
		public LanguageEnum DestinationLanguage;
		public Dictionary<string, DataTypeEnum> TypePairs = new Dictionary<string, DataTypeEnum>();

		public TypeMap(LanguageEnum sourceLanguage, LanguageEnum destinationLanguage) {
			SourceLanguage = sourceLanguage;
			DestinationLanguage = destinationLanguage;

			TypePairs.Add("string", DataTypeEnum.String);
			TypePairs.Add("bool", DataTypeEnum.Bool);
		}
	}
}