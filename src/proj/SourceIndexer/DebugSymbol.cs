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
		private readonly string toolPath;
		private readonly string symbolPath;
		private readonly string rootPath;
		private readonly ICollection<string> sourceFiles = new HashSet<string>();

		public DebugSymbol(string symbolPath, string toolPath, string rootPath)
		{
			this.symbolPath = symbolPath.Standardize();
			this.rootPath = rootPath.Standardize();
			this.toolPath = toolPath.Standardize();
			this.ReadSymbol();
		}

		private void ReadSymbol()
		{
			if (this.AlreadyIndexed())
				return;

			foreach (var file in this.GetSourceFiles())
				this.sourceFiles.Add(file);
		}
		private bool AlreadyIndexed()
		{
			var output = this.ExecuteRead(Resources.AlreadyIndexed.FormatWith(this.symbolPath));
			return output.Contains("source files are indexed") ||
			       output.Contains("source file is indexed");
		}

		private IEnumerable<string> GetSourceFiles()
		{
			var output = this.ExecuteRead(Resources.GetSourceFiles.FormatWith(this.symbolPath));
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

		private string ExecuteRead(string command)
		{
			var executable = Path.Combine(this.toolPath, ReadTool);
			return executable.ExecuteCommand(command);
		}
		private void ExecuteWrite(string command)
		{
			var executable = Path.Combine(this.toolPath, WriteTool);
			executable.ExecuteCommand(command);
		}
	}
}