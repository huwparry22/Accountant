using Accountant.Data;
using Accountant.Data.SqlServer;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectServices
    {
        public static void AddSqlServerServices(this IServiceCollection services, IHostEnvironment hostEnvironment)
        {
            services.AddTransient(typeof(IEntityProvider<>), typeof(EntityProvider<>));
        }
    }
}
