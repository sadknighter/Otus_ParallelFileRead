using Microsoft.Extensions.Configuration;
using ParallelFileRead.Models;

namespace ParallelFileRead.Interfaces
{
    public interface IConfigurationValidator
    {
        void Validate(IConfiguration configuration, List<ConfigurationKey> keys);
    }
}