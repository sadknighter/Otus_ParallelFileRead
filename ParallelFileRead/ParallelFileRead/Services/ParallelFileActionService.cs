using Microsoft.Extensions.Logging;
using ParallelFileRead.Interfaces;
using System.Diagnostics;

namespace ParallelFileRead.Services
{
    public class ParallelFileActionService : IParallelFileActionService
    {

        private readonly ILogger<IParallelFileActionService> _logger;

        public ParallelFileActionService(ILogger<IParallelFileActionService> logger)
        {
            _logger = logger;
        }

        public void ParallelFileAction(string filePath, char symbol, Func<string, int> func)
        {
            _logger.LogInformation("Started work of ParallelFileAction Metod");

            var directoryInfo = new DirectoryInfo(filePath);
            var files = directoryInfo.GetFiles();
            var sw = Stopwatch.StartNew();

            Parallel.ForEach(files, file =>
            {
                var text = File.ReadAllText(file.FullName);
                var symbolsCount = func(text);
                _logger.LogInformation("In file '{FullName}' found {symbolsCount} symbols({symbol})", file.FullName, symbolsCount, symbol);

            });

            sw.Stop();
            _logger.LogInformation("Executed time {ElapsedTicks}", sw.ElapsedTicks);
        }
    }
}
