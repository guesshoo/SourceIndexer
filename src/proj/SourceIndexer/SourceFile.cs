namespace SourceIndexer
{
	using System.Collections.Generic;
	using System.Linq;

	public class SourceFile
	{
		private readonly string value;

		public SourceFile(string filename, IEnumerable<string> arguments)
		{
			this.value = string.Join("*", new[] { filename } .Concat(arguments));
		}

		public override string ToString()
		{
			return this.value;
		}
	}
}