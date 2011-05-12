namespace SourceIndexer
{
	using System.Collections.Generic;

	public class NetworkShareIndexer : ISourceIndexer
	{
		public void Index(IEnumerable<DebugSymbol> symbols)
		{
			foreach (var symbol in symbols)
			{
				
			}
		}
	}
}