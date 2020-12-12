using System;
using CommandLine;
using System.Collections;
using System.Collections.Generic;
using spindll;
using System.Linq;

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
			var args = new string [2] { opts.Input, opts.Output };
			args = args.Select(a => a.Trim(' ')).ToArray();
			if (opts.Watch) {
				spindll.fileWatcher.fileWatcher.Main(args);
			} else {
				spindll.Spindll.ExtractAndWrite(args);
			}
			//handle options
		}
    }
}
