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
            services.AddTransient<ISubLineItemLogic, SubLineItemLogic>();
            services.AddTransient<IUserLogic, UserLogic>();

            services.AddTransient<ILineItemMapper, LineItemMapper>();
            services.AddTransient<ISubLineItemMapper, SubLineItemMapper>();
            services.AddTransient<ISubLineItemTypeMapper, SubLineItemTypeMapper>();
            services.AddTransient<IUserMapper, UserMapper>();
        }
    }
}
