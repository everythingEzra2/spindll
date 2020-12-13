using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using spindll.Logic;
using spindll.Models;
using spindll.Enum;

namespace spindll
{

	public class Spindll
	{

		public static string outputDirectory = @"/home/myr/_repo/spindll/spindll/_testOutputs/";        //xubuntu
		// const string outputDirectory = @"C:\_repo\spindll\_testOutputs\";        //40

		public static void ExtractAndWrite(string[] args)
        {
			var source = "";

			// source = @"C:\_repo\spindll\bin\Debug\netcoreapp3.0\spindll.dll";											//40
			// source = @"D:\_repo\spindll\bin\Debug\netcoreapp3.0\spindll.dll";											//tower - spindll
			// source = @"D:\_repo\f5saver\f5saver.api\F5Saver.Common\bin\Debug\netstandard2.0\F5Saver.Common.dll";			//tower - f5saver
			source = @"/home/myr/_repo/spindll/spindll/bin/Debug/netcoreapp3.0/spindll.dll";								//xubuntu
			// source = @"/home/myr/_repo/f5saver/f5saver.api/F5Saver.Common/bin/Debug/netstandard2.0/F5Saver.Common.dll";	//xubuntu

			if (args.Any()) {
				source = args[0];
				Console.WriteLine($"loading From: {source}");
				outputDirectory = args[1];
			}

			var types = ClassInspector.LoadDll(source).ToList();

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
					convertProperty(ref prop, inDict, outDict);
				});
			});

			var definedClasses = models.Select(m => m.ModelName).ToList();

			// build typescript class as string
			var modelClassStrings = models
				.ToDictionary(m => m.ModelName, m => buildClassString(m, definedClasses));
				

			foreach(var kvp in modelClassStrings) 
			{
				var filename = kvp.Key + ".ts";
				WriteStringToFile(filename, kvp.Value);
			}
        }

		static void convertProperty(ref PropertyInfo prop, Dictionary<string, string> inDict, Dictionary<string, string> outDict) {
			
			if (inDict.ContainsKey(prop.InputDataType)) {
				var intermediaryType = inDict[prop.InputDataType];
				prop.SystemDataType = (DataTypeEnum) System.Enum.Parse(typeof(Enum.DataTypeEnum) ,intermediaryType);
				prop.OutputDataType = outDict[intermediaryType];
				
			} else {
				var intermediaryType = prop.InputDataType;
				prop.SystemDataType = DataTypeEnum.DirectMap;
				prop.OutputDataType = intermediaryType;
			}

			prop.TypeArgs.ForEach(subProp => {
				convertProperty(ref subProp, inDict, outDict);
			});
		}

		static List<ModelInfo> extractModels(List<Type> types) 
		{
			var modelList = new List<ModelInfo>();

			var markedForCopyName = nameof(spindll.annotations.SpindllMark);
			var markedTypeList = types
				.Where(t => t.BaseType?.FullName != "System.Enum")
				.Where(a => a.CustomAttributes.Any(ca => ca.AttributeType.FullName.Contains(markedForCopyName)))
				.ToList();

			markedTypeList.ForEach(t => {
				var model = new ModelInfo(t);
				modelList.Add(model);
			});

			return modelList;
		}

		static string buildClassString(ModelInfo model, List<string> definedClasses) 
		{
			String classString = string.Empty;
			var builder = new System.Text.StringBuilder();

			// ----- [START] Imports -----
			// example: "import { Facility } from './Facility';"
			var definedClassesInModel = model.Properties
				.Where(p => definedClasses.Contains(p.InputDataType)) 
				.Select(p => p.InputDataType)
				.ToList();
			var definedClassesAsSubTypes = model.Properties
				.SelectMany(p => p.TypeArgs.Select(ta => ta.InputDataType))
				.Where(t => definedClasses.Contains(t))
				.ToList();
			definedClassesInModel.AddRange(definedClassesAsSubTypes);
			definedClassesInModel = definedClassesInModel.Distinct().ToList();

			if (definedClassesInModel.Any()) {
				definedClassesInModel.ForEach(dc => {
					builder.AppendLine($"import {{ { dc } }} from './{dc}';");
				});
			}
			builder.AppendLine();
			// ----- [ END ] Imports -----	

			// ----- [START] Class description -----
			builder.AppendLine($"export class {model.ModelName} {{\n");
			model.Properties.ForEach(p => {

				if (p.CustomAnnotations != null && p.CustomAnnotations.Any()) {
					var annotations = string.Join("", p.CustomAnnotations.Select(a => $"\t{a}\n").ToList());
					builder.Append(annotations);
					// builder.Append("\n");
				}

				if (p.SystemDataType == Enum.DataTypeEnum.Array || 
					p.SystemDataType == Enum.DataTypeEnum.List) {
					builder.Append($"\t{p.PropertyName}: {p.TypeArgs.First().OutputDataType}[]");
				} else {				
					builder.Append($"\t{p.PropertyName}: {p.OutputDataType}");
					
					if (p.HasTypeArgs) {
						
						var length = p.TypeArgs.Count;
						int iteration = 0;

						builder.Append($"<");
						p.TypeArgs.ForEach(ta => {
							builder.Append(ta.OutputDataType);

							iteration ++;
							if (iteration < length)
								builder.Append($",");
						});
						builder.Append($">");
					}
				}
				
				builder.AppendLine($";");
			});
			builder.AppendLine("\n}");
			// ----- [ END ] Class description -----

			return builder.ToString();
		}

		static void WriteStringToFile(string filename, string content) 
		{
			var outputFilePath = Path.Combine(outputDirectory, filename);
			Console.WriteLine($"write to: {outputFilePath}");
			System.IO.File.WriteAllText(outputFilePath, content);
		}
    }
}