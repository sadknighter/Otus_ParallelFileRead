namespace ParallelFileRead.Interfaces
{
    public interface IParallelFileActionService
    {
        void ParallelFileAction(string filePath, char symbol, Func<string, int> func);
    }
}