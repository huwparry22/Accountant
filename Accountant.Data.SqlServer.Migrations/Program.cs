using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace Accountant.Data.SqlServer.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            //Example usage after setup
            //var myService = serviceProvider.GetRequiredService<IMyService>();
            //myService.Execute();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
                {
                    configurationBuilder.AddSolutionConfiguration(hostBuilderContext.HostingEnvironment);
                })
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    services.AddSolutionServices(hostBuilderContext.HostingEnvironment);
                });
    }
}