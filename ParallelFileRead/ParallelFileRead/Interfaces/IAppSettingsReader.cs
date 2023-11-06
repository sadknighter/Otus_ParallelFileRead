using ParallelFileRead.Models;

namespace ParallelFileRead.Interfaces
{
    public interface IAppSettingsReader
    {
        AppSettings GetAppSettings();
    }
}