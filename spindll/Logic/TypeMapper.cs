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

		public static DataTypeEnum parseCSharp(string typeString) {
			var cSharpTypePairs = CSharpTypeMap();

			var type = cSharpTypePairs["typeString"];
			return type;
		}

		public static Dictionary<string, DataTypeEnum> CSharpTypeMap() {
			public Dictionary<string, DataTypeEnum> cSharpTypePairs = new Dictionary<string, DataTypeEnum>();

			cSharpTypePairs.Add("string", DataTypeEnum.String);
			cSharpTypePairs.Add("bool", DataTypeEnum.Bool);
			cSharpTypePairs.Add("datetime", DataTypeEnum.DateTime);
			cSharpTypePairs.Add("int", DataTypeEnum.Int);
			cSharpTypePairs.Add("long", DataTypeEnum.Long);

			return cSharpTypePairs;
		}
	}


}