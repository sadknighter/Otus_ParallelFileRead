using ParallelFileRead.Interfaces;

namespace ParallelFileRead.Services
{
    public class SymbolCounter : ISymbolCounter
    {
        public int CountSymbols(char countSymbol, string text)
        {
            return text.Count(x => x == countSymbol);
        }
    }
}
