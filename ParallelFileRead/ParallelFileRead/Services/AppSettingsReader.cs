using Microsoft.Extensions.Configuration;
using ParallelFileRead.Models;

namespace ParallelFileRead.Services
{
    public class AppSettingsReader
    {
        //FilesCount
        private const string GENERATION_SETTINGS_SECTION = "GenerationSettings";
        private const string FILES_FOLDER = "FilesFolder";
        private const string ENABLED_GENERATION_KEY = "Enabled";
        private const string FILES_COUNT_KEY = "FilesCount";

        private readonly IConfiguration _configuration;

        public AppSettingsReader(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppSettings GetAppSettings()
        {
            var section = _configuration.GetSection(GENERATION_SETTINGS_SECTION);
            var generationEnabled = Convert.ToBoolean(section[ENABLED_GENERATION_KEY]);
            var generationFilesCount = Convert.ToInt32(section[FILES_COUNT_KEY]);

            var generationSettings = new GenerationSettings(generationEnabled, generationFilesCount);
            var filesFolder = _configuration[FILES_FOLDER];

            if (string.IsNullOrEmpty(filesFolder))
            {
                throw new MissingFieldException("Missed configuration parameter", nameof(filesFolder));
            }

            return new AppSettings(filesFolder, generationSettings);
        }
    }
}
