using Accountant.API.WebAPI.Interfaces;

namespace Accountant.API.WebAPI.Aggregators
{
    public class ApiLogicAggregator : IApiLogicAggregator
    {
        public IAuthenticateUserLogic AuthenticateUserLogic { get; }
        public IApiProcessLogic ApiProcessLogic { get; }

        public ApiLogicAggregator(IAuthenticateUserLogic authenticateUserLogic, IApiProcessLogic apiProcessLogic)
        {
            AuthenticateUserLogic = authenticateUserLogic;
            ApiProcessLogic = apiProcessLogic;
        }
    }
}
