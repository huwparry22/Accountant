using Accountant.Data;
using Accountant.Data.EntityProviders;
using Accountant.Data.SqlServer;
using Accountant.Data.SqlServer.Context;
using Accountant.Data.SqlServer.EntityProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectServices
    {
        public static void AddSqlServerServices(this IServiceCollection services, IHostEnvironment hostEnvironment)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            services.AddDbContext<AccountantContext>(options => options.UseSqlServer(configuration.GetConnectionString("Accountant")));

            services.AddTransient(typeof(IEntityProvider<>), typeof(EntityProvider<>));

            services.AddTransient<IUserProvider, UserProvider>();
            services.AddTransient<ILineItemProvider, LineItemProvider>();
            services.AddTransient<ISubLineItemProvider, SubLineItemProvider>();
        }
    }
}
