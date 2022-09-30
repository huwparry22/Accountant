using Accountant.Core.Interfaces;
using Accountant.Core.Logic;
using Accountant.Core.Mappers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectServiceCollectionHelper
    {
        public static void AddCoreProjectServices(this IServiceCollection services)
        {
            services.AddTransient<ILineItemLogic, LineItemLogic>();

            services.AddTransient<ILineItemMapper, LineItemMapper>();
        }
    }
}
