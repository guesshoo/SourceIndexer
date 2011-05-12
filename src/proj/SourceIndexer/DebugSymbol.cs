namespace SourceIndexer
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	public class DebugSymbol
	{
		private const string ReadTool = "srctool.exe";
		private const string WriteTool = "pdbstr.exe";
		private readonly string symbolPath;
		private readonly string rootPath;

		public ICollection<string> SourceFiles { get; private set; }

		public DebugSymbol(string symbolPath, string rootPath)
		{
			this.SourceFiles = new HashSet<string>();
			this.symbolPath = symbolPath.Standardize();
			this.rootPath = rootPath.Standardize();
			this.ReadSymbol();
		}

		private void ReadSymbol()
		{
			if (this.AlreadyIndexed())
				return;

			foreach (var file in this.GetSourceFiles())
				this.SourceFiles.Add(file);

			Console.WriteLine(
				"Discovered {0} indexable source files in '{1}'",
				this.SourceFiles.Count,
				this.symbolPath);
		}
		private bool AlreadyIndexed()
		{
			var output = ExecuteRead(Resources.AlreadyIndexed.FormatWith(this.symbolPath));
			return output.Contains("source files are indexed") ||
			       output.Contains("source file is indexed");
		}

		private IEnumerable<string> GetSourceFiles()
		{
			var output = ExecuteRead(Resources.GetSourceFiles.FormatWith(this.symbolPath));
			return output.Enumerate()
				.Where(item => !IsCPlusPlusFile(item))
				.Select(item => item.Standardize())
				.Where(x => x.StartsWith(this.rootPath, StringComparison.InvariantCultureIgnoreCase))
				.Where(File.Exists);
		}
		private static bool IsCPlusPlusFile(string item)
		{
			return (item.IndexOf('*') >= 0) || ((item.Length > 2) && (item.IndexOf(':', 2) >= 0));
		}

		public void Write(EmbeddedSymbolStream stream)
		{
			var output = stream.ToString();
			if (string.IsNullOrEmpty(output))
				return;

			var temporaryFile = Path.GetTempFileName();
			try
			{
				File.WriteAllText(temporaryFile, output);
				this.ExecuteWrite(Resources.WriteCommand.FormatWith(this.symbolPath, temporaryFile));
			}
			finally
			{
				File.Delete(temporaryFile);
			}
		}

		private static string ExecuteRead(string command)
		{
			return ReadTool.ExecuteCommand(command);
		}
		private void ExecuteWrite(string command)
		{
			Console.WriteLine("Rewriting indexed debug database '{0}'", this.symbolPath);
			WriteTool.ExecuteCommand(command);
		}
	}
}