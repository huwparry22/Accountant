using Accountant.API.Models;
using Accountant.API.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Accountant.API.WebAPI.Logic
{
    public class ApiLogic : IApiLogic
    {
        private readonly IAuthenticateUserLogic _authenticateUserLogic;
        private readonly IApiProcessLogic _apiProcessLogic;
        
        public ApiLogic(IAuthenticateUserLogic authenticateUserLogic, IApiProcessLogic apiProcessLogic)
        {
            _authenticateUserLogic = authenticateUserLogic;
            _apiProcessLogic = apiProcessLogic;
        }

        public async Task<TResponse> RunApiProcess<TRequest, TResponse>(TRequest request, ClaimsPrincipal user)
            where TRequest : BaseRequest
            where TResponse : BaseResponse
        {
            request.AuthenticatedUser = await _authenticateUserLogic.GetAuthenticatedUser(user).ConfigureAwait(false);

            return await _apiProcessLogic.RunApiProcess<TRequest, TResponse>(request).ConfigureAwait(false);
        }
    }
}
