using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Accountant.SolutionBuilder
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
