using Microsoft.Extensions.Logging;
using ParallelFileRead.Interfaces;
using ParallelFileRead.Models;

namespace ParallelFileRead.Services
{
    public class ConsoleUiService : IConsoleUiService
    {
        private readonly ILogger<IConsoleUiService> _logger;
        private readonly IAppSettingsReader _appSettingsReader;
        private readonly IAppSettingsChanger _appSettingsChanger;
        private readonly IParallelFileActionService _parallelFileActionService;
        private readonly IFileActionService _fileActionService;
        private readonly IFilesGenerator _filesGenerator;
        private readonly ISymbolCounter _symbolCounter;


        public ConsoleUiService(
            IAppSettingsReader appSettingsReader,
            IAppSettingsChanger appSettingsChanger,
            IParallelFileActionService parallelFileActionService,
            IFileActionService fileActionService,
            ISymbolCounter symbolCounter,
            IFilesGenerator filesGenerator,
            ILogger<IConsoleUiService> logger)
        {
            _logger = logger;
            _appSettingsReader = appSettingsReader;
            _appSettingsChanger = appSettingsChanger;
            _parallelFileActionService = parallelFileActionService;
            _fileActionService = fileActionService;
            _symbolCounter = symbolCounter;
            _filesGenerator = filesGenerator;
        }

        public void Run()
        {
            var conditionToContinue = true;
            _logger.LogInformation("ConsoleUiService started");

            while (conditionToContinue)
            {
                AppSettings settings = _appSettingsReader.GetAppSettings();
                Console.WriteLine("Default settings for this Application:");
                
                Console.WriteLine("Folder for counting symbols in files: {0}", settings.FilesFolder);
                string symbolStr = Convert.ToString(settings.SymbolForCounting);
                if (symbolStr == " ")
                {
                    symbolStr = "spacebar";
                }

                Console.WriteLine("Symbol for counting in files: '{0}'", symbolStr);
                _appSettingsChanger.TryToChangeDirectory(settings);
                _appSettingsChanger.TryToChangeSymbolForCounting(settings);

                if (settings.GenerationSettings.Enabled)
                {
                    Console.WriteLine("Generation settings enabled for selected directory");
                    Console.WriteLine("Will be generated {0} files", settings.GenerationSettings.FilesCount);
                    _filesGenerator.Generate(settings);

                    Console.WriteLine("-----");

                }


                _parallelFileActionService.ParallelFileAction(settings.FilesFolder, settings.SymbolForCounting, (string text) => { return _symbolCounter.CountSymbols(settings.SymbolForCounting, text); });
                _fileActionService.SimpleForeachAction(settings.FilesFolder, settings.SymbolForCounting, (string text) => { return _symbolCounter.CountSymbols(settings.SymbolForCounting, text); });

                Console.WriteLine("Press 'exit' if you want to close the program");
                var input = Console.ReadLine();

                if (input =="exit")
                {
                    conditionToContinue = false;
                }
            }
        }
    }
}
