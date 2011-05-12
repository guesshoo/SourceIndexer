namespace SourceIndexer
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	internal class Program
	{
		private static void Main(string[] args)
		{
			var outputPath = string.Empty;
			var toolPath = string.Empty;
			var rootPath = string.Empty;
			var files = new List<string>();
			var options = new Mono.Options.OptionSet
			{
				{ "o|output:", "The path to which the source code files will be copied.", x => outputPath = x },
				{ "t|tools:", "The path which contains the srctool.exe and pdbstr.exe files.", x => toolPath = x },
				{ "r|root:", "The root path under which all source code files belong.", x => rootPath = x },
				{ "p|pdb:", "The fully qualified path to the one or more debug (PDB) files.", files.Add }
			};
			options.Parse(args);

			var symbols = files.Select(x => x.Standardize())
				.Where(File.Exists)
				.Select(x => new DebugSymbol(x, toolPath, rootPath))
				.ToArray();

			var indexer = new NetworkShareIndexer(outputPath);
			foreach (var symbol in symbols)
				indexer.Index(symbol);
		}
	}
}