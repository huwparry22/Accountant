using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionHelper
    {
        public static IServiceCollection AddSolutionServices(this IServiceCollection services, IHostEnvironment hostEnvironment)
        {
            services.AddSqlServerServices(hostEnvironment);
            services.AddCoreProjectServices();
            services.AddApiProjectServices();

            return services;
        }
    }
}