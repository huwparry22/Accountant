using Accountant.Data;
using Accountant.Data.EntityProviders;
using Accountant.Data.SqlServer;
using Accountant.Data.SqlServer.Context;
using Accountant.Data.SqlServer.EntityProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectServices
    {
        public static void AddSqlServerServices(this IServiceCollection services, IHostEnvironment hostEnvironment)
        {
            var constStr = @"Data Source=(localdb)\ProjectModels;Initial Catalog=Accountant;Integrated Security=True";
            services.AddDbContext<AccountantContext>(options => options.UseSqlServer(constStr));


            services.AddTransient(typeof(IEntityProvider<>), typeof(EntityProvider<>));

            services.AddTransient<IUserProvider, UserProvider>();
            services.AddTransient<ILineItemProvider, LineItemProvider>();
            services.AddTransient<ISubLineItemProvider, SubLineItemProvider>();
        }
    }
}
