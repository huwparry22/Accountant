using Accountant.API.Models;
using Accountant.API.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Accountant.API.WebAPI.Logic
{
    public class ApiLogic : ControllerBase
    {
        private IAuthenticateUserLogic _authenticateUserLogic;
        private IApiProcessLogic _apiProcessLogic;

        public ApiLogic(IApiLogicAggregator apiLogicAggregator)
        {
            _authenticateUserLogic = apiLogicAggregator.AuthenticateUserLogic;
            _apiProcessLogic = apiLogicAggregator.ApiProcessLogic;
        }

        public async Task<TResponse> RunApiProcess<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest
            where TResponse : BaseResponse
        {
            request.AuthenticatedUser = await _authenticateUserLogic.GetAuthenticatedUser(User).ConfigureAwait(false);

            return await _apiProcessLogic.RunApiProcess<TRequest, TResponse>(request).ConfigureAwait(false);
        }
    }
}
