using Microsoft.Extensions.Configuration;

namespace ParallelFileRead.Services
{
    public class AppSettingsBuilder
    {
        public static void BuildConfig(IConfigurationBuilder builder)
        {
            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
        }
    }
}
