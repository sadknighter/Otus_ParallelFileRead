using ParallelFileRead.Models;

namespace ParallelFileRead.Interfaces
{
    public interface IAppSettingsChanger
    {
        void TryToChangeDirectory(AppSettings settings);
        void TryToChangeSymbolForCounting(AppSettings settings);
    }
}