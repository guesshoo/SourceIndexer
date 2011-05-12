namespace SourceIndexer
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class EmbeddedSymbolStream
	{
		private readonly IDictionary<string, string> variables;
		private readonly string resolvedFilePath;
		private readonly string resolveFileCommand;
		private readonly ICollection<SourceFile> files;

		public EmbeddedSymbolStream(
			IDictionary<string, string> variables,
			string resolvedFilePath,
			string resolveFileCommand,
			IEnumerable<SourceFile> files)
		{
			this.variables = variables;
			this.resolveFileCommand = resolveFileCommand;
			this.resolvedFilePath = resolvedFilePath;
			this.files = (files ?? new SourceFile[0]).Where(x => x != null).ToArray();
		}

		public override string ToString()
		{
			if (this.files.Count == 0)
				return string.Empty;

			return Resources.SymbolStream.FormatWith(
				DateTime.UtcNow,
				this.FormatVariables(),
				this.resolvedFilePath,
				this.resolveFileCommand,
				this.FormatFiles()) + Environment.NewLine;
		}

		private string FormatVariables()
		{
			var builder = new StringBuilder();
			foreach (var item in this.variables)
				builder.AppendLine("{0}={1}".FormatWith(item.Key, item.Value));
			return builder.ToString();
		}
		private string FormatFiles()
		{
			var builder = new StringBuilder();
			foreach (var file in this.files)
				builder.AppendLine(file.ToString());
			return builder.ToString();
		}
	}
}