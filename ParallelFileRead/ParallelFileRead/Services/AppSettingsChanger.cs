using Microsoft.Extensions.Logging;
using ParallelFileRead.Interfaces;
using ParallelFileRead.Models;

namespace ParallelFileRead.Services
{
    public class AppSettingsChanger : IAppSettingsChanger
    {
        private readonly ILogger<AppSettingsChanger> _logger;

        public AppSettingsChanger(ILogger<AppSettingsChanger> logger) 
        {
            _logger = logger;
        }

        public void TryToChangeDirectory(AppSettings settings)
        {
            Console.WriteLine("You can change directory. Press Y, if you want or another symbol");
            if (Console.ReadLine() == "Y")
            {
                Console.Write("Input directory path: ");
                var filesFolder = Console.ReadLine();

                if (!string.IsNullOrEmpty(filesFolder)) 
                {
                    var previousDirectory = settings.FilesFolder;
                    settings.ChangeFilesFolder(filesFolder);
                    _logger.LogInformation("Directory changed from '{previousDirectory}' to '{FilesFolder}'", previousDirectory, settings.FilesFolder);

                    if (!Directory.Exists(settings.FilesFolder))
                    {
                        Directory.CreateDirectory(settings.FilesFolder);
                    }
                }

            }
        }

        public void TryToChangeSymbolForCounting(AppSettings settings)
        {
            Console.WriteLine("You can change symbol for counting. Press Y, if you want or another symbol");
            if (Console.ReadLine() == "Y")
            {
                Console.Write("Input symbol for counting in files: ");
                var filesFolder = Console.ReadLine();

                if (!string.IsNullOrEmpty(filesFolder))
                {
                    var previousSymbol = settings.SymbolForCounting;
                    settings.ChangeSymbolForCounting(Convert.ToChar(filesFolder));
                    _logger.LogInformation("Symbol changed from '{previousSymbol}' to '{settings.SymbolForCounting}'", previousSymbol, settings.SymbolForCounting);
                }

            }
        }
    }
}
