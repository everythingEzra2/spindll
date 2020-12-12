using CommandLine;
using System.Collections;

namespace spindll.cli
{
	public class Options
	{
		[Option('w', "watch", Default = false, HelpText = "watches the file. will trigger a spindll run if the watched file changes.")]
		public bool Watch { get; set; }

		[Option('i', "input", Required = true, HelpText = "Input files to be processed.")]
		public string Input { get; set; }

		[Option('o', "output", Required = true, HelpText = "output directory to dump extracted contents.")]
		public string Output { get; set; }
	}
}