using Accountant.API.Models;
using Accountant.API.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<ActionResult<TResponse>> RunApiProcess<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest
            where TResponse : BaseResponse
        {
            var authResponse = await _authenticateUserLogic.GetAuthenticatedUser(User).ConfigureAwait(false);
            
            if (!authResponse.Response.Success)
            {
                return Unauthorized(authResponse.Response.Errors);
            }

            request.AuthenticatedUser = authResponse.User;

            return await _apiProcessLogic.RunApiProcess<TRequest, TResponse>(request).ConfigureAwait(false);
        }
    }
}
