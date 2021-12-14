using Accountant.Data;
using Accountant.Data.EntityProviders;
using Accountant.Data.SqlServer;
using Accountant.Data.SqlServer.EntityProviders;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectServices
    {
        public static void AddSqlServerServices(this IServiceCollection services, IHostEnvironment hostEnvironment)
        {
            services.AddTransient(typeof(IEntityProvider<>), typeof(EntityProvider<>));

            services.AddTransient<IUserProvider, UserProvider>();
        }
    }
}
