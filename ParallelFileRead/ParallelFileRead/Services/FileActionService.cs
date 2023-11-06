using Microsoft.Extensions.Logging;
using ParallelFileRead.Interfaces;
using System.Diagnostics;

namespace ParallelFileRead.Services
{
    public class FileActionService : IFileActionService
    {
        private readonly ILogger<IFileActionService> _logger;

        public FileActionService(ILogger<IFileActionService> logger)
        {
            _logger = logger;
        }

        public void SimpleForeachAction(string filePath, char symbol, Func<string, int> func)
        {
            _logger.LogInformation("Started work of SimpleForeachAction Metod");
            var directoryInfo = new DirectoryInfo(filePath);
            var files = directoryInfo.GetFiles();
            var sw = Stopwatch.StartNew();

            foreach (var file in files)
            {
                var text = File.ReadAllText(file.FullName);
                var symbolsCount = func(text);
                _logger.LogInformation("In file '{FullName}' found {symbolsCount} symbols({symbol})", file.FullName, symbolsCount, symbol);
            }

            sw.Stop();
            _logger.LogInformation("Executed time {ElapsedTicks}", sw.ElapsedTicks);
        }
    }
}
