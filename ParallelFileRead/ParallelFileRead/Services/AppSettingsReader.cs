using Microsoft.Extensions.Configuration;
using ParallelFileRead.Interfaces;
using ParallelFileRead.Models;

namespace ParallelFileRead.Services
{
    public class AppSettingsReader : IAppSettingsReader
    {
        //FilesCount
        private const string GENERATION_SETTINGS_SECTION = "GenerationSettings";
        private const string FILES_FOLDER = "FilesFolder";
        private const string ENABLED_GENERATION_KEY = "Enabled";
        private const string FILES_COUNT_KEY = "FilesCount";
        private const string SYMBOL_FOR_COUNTING = "SymbolForCounting";
        private const string GENERATION_SETTINGS_SECTION_NAME = "GenerationSettings";
        private readonly string _defaultSymbolForCounting = " ";
        private readonly string _defaultFileFolder = "C:\\Temp";
        private readonly IConfiguration _configuration;
        private readonly IConfigurationValidator _configurationValidator;

        public AppSettingsReader(IConfiguration configuration, IConfigurationValidator configurationValidator)
        {
            _configuration = configuration;
            _configurationValidator = configurationValidator;
        }

        public AppSettings GetAppSettings()
        {
            var keys = new List<ConfigurationKey>
            {
                new ConfigurationKey { Key = FILES_FOLDER },
                new ConfigurationKey { Key = SYMBOL_FOR_COUNTING },
                new ConfigurationKey { Key = ENABLED_GENERATION_KEY, Section = GENERATION_SETTINGS_SECTION_NAME },
                new ConfigurationKey { Key = FILES_COUNT_KEY, Section = GENERATION_SETTINGS_SECTION_NAME }
            };

            _configurationValidator.Validate(_configuration, keys);

            var section = _configuration.GetSection(GENERATION_SETTINGS_SECTION);
            var generationEnabled = Convert.ToBoolean(section[ENABLED_GENERATION_KEY]);
            var generationFilesCount = Convert.ToInt32(section[FILES_COUNT_KEY]);
            var generationSettings = new GenerationSettings(generationEnabled, generationFilesCount);

            string filesFolder = _configuration[FILES_FOLDER] ?? _defaultFileFolder;
            string symbolForCounting = _configuration[SYMBOL_FOR_COUNTING] ?? _defaultSymbolForCounting;


            return new AppSettings(filesFolder, Convert.ToChar(symbolForCounting), generationSettings);
        }
    }
}
