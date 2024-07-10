using Accountant.API.WebAPI.Aggregators;
using Accountant.API.WebAPI.Interfaces;
using Accountant.API.WebAPI.Logic;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectServiceCollectionHelper
    {
        public static void AddWebApiProjectServices(this IServiceCollection services)
        {
            services.AddTransient<IApiLogicAggregator, ApiLogicAggregator>();

            services.AddTransient<IAuthenticateUserLogic, AuthenticateUserLogic>();
            services.AddTransient<IApiProcessLogic, ApiProcessLogic>();
        }
    }
}
