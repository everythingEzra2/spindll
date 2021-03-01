using System.Collections.Generic;
using spindll.Enum;
using System;

namespace spindll.Logic {

	public class LanguageMappingDictionary {
		public Dictionary<LanguagePair, Dictionary<string, string>> LanguageDictionary = new Dictionary<LanguagePair, Dictionary<string, string>>();

		public LanguageMappingDictionary(params LanguagePair[] languagePairs) {
			foreach (var languagePair in languagePairs) {
				var languageMap = getLanguagePairDictionary(languagePair);

				LanguageDictionary.Add(languagePair, languageMap);
			}
		}

		public Dictionary<string, string> this[LanguagePair languagePair] {
			get => LanguageDictionary[languagePair];
		}

		private Dictionary<string, string> getLanguagePairDictionary(LanguagePair languagePair) {
			// Input Language to System
			if (languagePair.SourceLanguage == LanguageEnum.CSharp && languagePair.DestinationLanguage == LanguageEnum.System) {
				return LanguageMappingProfiles.CSharpToSystemTypeMap();
			}

			// System to Output Language
			if (languagePair.SourceLanguage == LanguageEnum.System && languagePair.DestinationLanguage == LanguageEnum.TypeScript) {
				return LanguageMappingProfiles.SystemToTypeScriptTypeMap();
			}

			throw new Exception("type map not configured");
		}
	}

	public class LanguagePair {
		public LanguageEnum SourceLanguage;
		public LanguageEnum DestinationLanguage;

		public LanguagePair(LanguageEnum sourceLanguage, LanguageEnum destinationLanguage) {
			SourceLanguage = sourceLanguage;
			DestinationLanguage = destinationLanguage;
		}
	}

	public static class LanguageMappingProfiles {

		public static Dictionary<string, string> CSharpToSystemTypeMap()
		{
			var cSharpTypePairs = new Dictionary<string, string>();

			cSharpTypePairs.Add("String", DataTypeEnum.String.ToString());
			cSharpTypePairs.Add("Boolean", DataTypeEnum.Bool.ToString());
			cSharpTypePairs.Add("DateTime", DataTypeEnum.DateTime.ToString());
			cSharpTypePairs.Add("Int32", DataTypeEnum.Int.ToString());
			cSharpTypePairs.Add("Int64", DataTypeEnum.Int.ToString());
			cSharpTypePairs.Add("Long", DataTypeEnum.Long.ToString());
			cSharpTypePairs.Add("List`1", DataTypeEnum.List.ToString());
			cSharpTypePairs.Add("Array`1", DataTypeEnum.Array.ToString());
			cSharpTypePairs.Add("Nullable`1", DataTypeEnum.Unwrap.ToString());

			return cSharpTypePairs;
		}

		public static Dictionary<string, string> SystemToTypeScriptTypeMap()
		{
			var dataTypeMappings = new Dictionary<string, string>();

			dataTypeMappings.Add(DataTypeEnum.String.ToString(), "string");
			dataTypeMappings.Add(DataTypeEnum.Bool.ToString(), "boolean");
			dataTypeMappings.Add(DataTypeEnum.DateTime.ToString(), "Date");
			dataTypeMappings.Add(DataTypeEnum.Int.ToString(), "number");
			dataTypeMappings.Add(DataTypeEnum.Long.ToString(), "number");
			dataTypeMappings.Add(DataTypeEnum.List.ToString(), "List");
			dataTypeMappings.Add(DataTypeEnum.Array.ToString(), "Array");

			return dataTypeMappings;
		}

	}
}