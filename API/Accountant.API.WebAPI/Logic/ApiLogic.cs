using Accountant.API.Models;
using Accountant.API.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Accountant.API.WebAPI.Logic
{
    public class ApiLogic : ControllerBase, IApiLogic
    {
        private readonly IAuthenticateUserLogic _authenticateUserLogic;
        private readonly IApiProcessLogic _apiProcessLogic;
        
        public ApiLogic(IAuthenticateUserLogic authenticateUserLogic, IApiProcessLogic apiProcessLogic)
        {
            _authenticateUserLogic = authenticateUserLogic;
            _apiProcessLogic = apiProcessLogic;
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
