using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ParallelFileRead.Interfaces;
using ParallelFileRead.Models;

namespace ParallelFileRead.Services
{
    public class ConfigurationValidator : IConfigurationValidator
    {
        private const string ERROR_STRING_PART = "Missed configuration parameter {key}";
        private readonly ILogger<IConfigurationValidator> _logger;

        public ConfigurationValidator(ILogger<IConfigurationValidator> logger)
        { 
            _logger = logger;
        }

        public void Validate(IConfiguration configuration, List<ConfigurationKey> keys)
        {
            foreach (var key in keys)
            {
                if (!string.IsNullOrEmpty(key.Section))
                {
                    var sectionName = key.Section;
                    var section = configuration.GetSection(sectionName);

                    if (string.IsNullOrEmpty(section[key.Key]))
                    {
                        ThrowException(key.Key, key.Section);
                    }

                }

                else if (string.IsNullOrEmpty(configuration[key.Key]))
                {
                    ThrowException(key.Key, key.Section);
                }
            }
        }

        private void ThrowException(string keyName, string? sectionName)
        {
            sectionName = sectionName ?? "root";
            var exception = new MissingFieldException($"{ERROR_STRING_PART} , {keyName}.{sectionName}");
            _logger.LogError(0, exception, exception.Message);
            throw exception;
        }
    }
}
