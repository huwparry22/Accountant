using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.Data.SqlServer.DependencyResolution
{
    public static class ProjectServices
    {
        public static void AddSqlServerServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IEntityProvider<>), typeof(EntityProvider<>));
        }
    }
}
