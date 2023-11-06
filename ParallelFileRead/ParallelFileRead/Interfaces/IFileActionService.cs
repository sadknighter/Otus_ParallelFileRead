namespace ParallelFileRead.Interfaces
{
    public interface IFileActionService
    {
        void SimpleForeachAction(string filePath, char symbol, Func<string, int> func);
    }
}