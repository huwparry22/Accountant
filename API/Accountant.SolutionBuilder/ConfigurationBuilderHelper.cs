using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationBuilderHelper
    {
        public static IConfigurationBuilder AddSolutionConfiguration(this IConfigurationBuilder configurationBuilder, IHostEnvironment hostEnvironment)
        {
            configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);            

            return configurationBuilder;
        }
    }
}
