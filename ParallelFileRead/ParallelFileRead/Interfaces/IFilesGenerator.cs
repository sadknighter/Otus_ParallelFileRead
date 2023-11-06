using ParallelFileRead.Models;

namespace ParallelFileRead.Interfaces
{
    public interface IFilesGenerator
    {
        void Generate(AppSettings settings);
    }
}