using System;
using CommandLine;
using System.Collections;
using System.Collections.Generic;

namespace spindll.cli
{
    class Program
    {
		static void Main(string[] args)
		{
			Console.WriteLine(string.Join(", ", args));
			CommandLine.Parser.Default.ParseArguments<Options>(args)
				.WithParsed(RunOptions);
				// .WithNotParsed(HandleParseError);
		}
		static void RunOptions(Options opts)
		{
			//handle options
		}
		static void HandleParseError(List<Error> errs)
		{
			foreach (var error in errs)
			{
				// Console.log(error)	
			}
			//handle errors
		}
    }
}
