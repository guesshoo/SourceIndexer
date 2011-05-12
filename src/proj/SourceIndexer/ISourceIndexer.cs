namespace SourceIndexer
{
	using System.Collections.Generic;

	public interface ISourceIndexer
	{
		void Index(IEnumerable<DebugSymbol> symbols);
	}
}