using System;
using System.Collections.Generic;
using System.Linq;
using spindll.Logic;
using spindll.Models;
using spindll.Enum;

namespace spindll
{
    class Program
    {
		// const string outputDirectory = @"/home/myr/_repo/spindll/_testOutputs/";        //xubuntu
		const string outputDirectory = @"C:\_repo\spindll\_testOutputs\";        //40

		static void Main(string[] args)
        {
			var types = ClassInspector.LoadDll(@"C:\_repo\spindll\bin\Debug\netcoreapp3.0\spindll.dll").ToList();											//40
			// var types = ClassInspector.LoadDll(@"D:\_repo\spindll\bin\Debug\netcoreapp3.0\spindll.dll").ToList();												//tower - spindll
			// var types = ClassInspector.LoadDll(@"D:\_repo\f5saver\f5saver.api\F5Saver.Common\bin\Debug\netstandard2.0\F5Saver.Common.dll").ToList();			//tower - f5saver
			// var types = ClassInspector.LoadDll(@"/home/myr/_repo/spindll/bin/Debug/netcoreapp3.0/spindll.dll").ToList();										//xubuntu
			// var types = ClassInspector.LoadDll(@"/home/myr/_repo/f5saver/f5saver.api/F5Saver.Common/bin/Debug/netstandard2.0/F5Saver.Common.dll").ToList();	//xubuntu

			var models = extractModels(types);

			//convert types to System
			var CSharpIn = new LanguagePair(LanguageEnum.CSharp, LanguageEnum.System);
			var TypeScriptOut = new LanguagePair(LanguageEnum.System, LanguageEnum.TypeScript);
			var languageDictionary = new LanguageMappingDictionary(CSharpIn, TypeScriptOut);
			var inDict = languageDictionary[CSharpIn];
			var outDict = languageDictionary.LanguageDictionary[TypeScriptOut];

			// fill out intermediary types
			models.ForEach(model => {
				model.Properties.ForEach(prop => {
					if (inDict.ContainsKey(prop.InputDataType)) {
						var intermediaryType = inDict[prop.InputDataType];
						prop.SystemDataType = (DataTypeEnum) System.Enum.Parse(typeof(Enum.DataTypeEnum) ,intermediaryType);
						prop.OutputDataType = outDict[intermediaryType];
					} else {
						var intermediaryType = prop.InputDataType;
						prop.SystemDataType = DataTypeEnum.DirectMap;
						prop.OutputDataType = intermediaryType;
					}
				});
			});

			// build typescript class as string
			var modelClassStrings = models
				.ToDictionary(m => m.ModelName, m => buildClassString(m));
				

			foreach(var kvp in modelClassStrings) 
			{
				WriteStringToFile(kvp.Key, kvp.Value);
			}
        }

		static List<ModelInfo> extractModels(List<Type> types) 
		{
			var testTargets = new List<string>() { "Dog", "Leaf" };

			var modelList = new List<ModelInfo>();
			var typeList = types
				.Where(t => t.BaseType?.FullName != "System.Enum")
				.Where(t => testTargets.Any(tt => t.AssemblyQualifiedName.Contains(tt)))
				.ToList();

			typeList.ForEach(t => {
				var model = new ModelInfo(t);
				modelList.Add(model);
			});

			return modelList;
		}

		static string buildClassString(ModelInfo model) 
		{
			String classString = string.Empty;
			var builder = new System.Text.StringBuilder();

			builder.AppendLine($"export class {model.ModelName} {{\n");
			model.Properties.ForEach(p => {
				builder.AppendLine($"\t{p.PropertyName}: {p.OutputDataType};");
			});
			builder.AppendLine("\n}");

			return builder.ToString();
		}

		static void WriteStringToFile(string filename, string content) 
		{
			var completeFilePath = $"{outputDirectory}{filename}.ts";
			System.IO.File.WriteAllText(completeFilePath, content);
		}
    }
}