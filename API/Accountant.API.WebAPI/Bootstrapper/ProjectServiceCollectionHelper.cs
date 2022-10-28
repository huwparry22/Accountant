using Accountant.API.WebAPI;
using Accountant.API.WebAPI.Logic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectServiceCollectionHelper
    {
        public static void AddWebApiProjectServices(this IServiceCollection services)
        {
            services.AddTransient<IApiLogic, ApiLogic>();
        }
    }
}
