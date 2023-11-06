using Microsoft.Extensions.Logging;
using ParallelFileRead.Interfaces;
using ParallelFileRead.Models;
using System.Text;

namespace ParallelFileRead.Services
{
    public class FilesGenerator : IFilesGenerator
    {
        private readonly ILogger<IFilesGenerator> _logger;
        public FilesGenerator(ILogger<IFilesGenerator> logger)
        {
            _logger = logger;
        }

        public void Generate(AppSettings settings)
        {
            if (!settings.GenerationSettings.Enabled)
            {
                _logger.LogInformation("Generating files was disabled. Generation will be missed");
            }

            Directory.SetCurrentDirectory(settings.FilesFolder.ToString());
            var filesCountInDirectory = Directory.GetFiles(settings.FilesFolder, "*", SearchOption.TopDirectoryOnly).Length;

            var leftForCreate = settings.GenerationSettings.FilesCount - filesCountInDirectory;
            _logger.LogInformation("Will be generated files count: {leftForCreate}", leftForCreate);

            _logger.LogInformation("Started generation files:");

            for (int i = 0; i < leftForCreate; i++)
            {
                var generatedFileText = GenerateBodyTextFile(i);
                var fileName = "File_" + i + "_" + DateTime.UtcNow.ToString("_dd_hh-mm-ss") + ".txt";
                _logger.LogInformation("Generated string content for file: {fileName}", fileName);
                File.WriteAllText(fileName, generatedFileText);
            }
        }

        private static string GenerateBodyTextFile(int indexFile)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Header for file: " + indexFile);
            sb.AppendLine("Article text for file: " + indexFile);

            for (var i = 0; i < 50000 + indexFile; i++)
            {
                sb.AppendLine("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ");
                sb.AppendLine("Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. ");
                sb.AppendLine("Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. ");
                sb.AppendLine("Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. ");
            }

            sb.AppendLine("End of file: " + indexFile);

            return sb.ToString();
        }
    }
}
