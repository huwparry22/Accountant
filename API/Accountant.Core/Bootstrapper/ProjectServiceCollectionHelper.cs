using Accountant.Core.Interfaces;
using Accountant.Core.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectServiceCollectionHelper
    {
        public static void AddCoreProjectServices(this IServiceCollection services)
        {
            services.AddTransient<ILineItemLogic, LineItemLogic>();
        }
    }
}
