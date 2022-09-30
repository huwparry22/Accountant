using Accountant.Core.Interfaces;
using Accountant.Core.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace Accountant.Core.Bootstrapper
{
    public static class ProjectServiceCollectionHelper
    {
        public static void AddCoreProjectServices(this IServiceCollection services)
        {
            services.AddTransient<ILineItemLogic, LineItemLogic>();
        }
    }
}
