using Accountant.API.Interfaces;
using Accountant.API.Models;
using Accountant.API.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Accountant.API.WebAPI.Logic
{
    public class ApiLogic : ControllerBase, IApiLogic
    {
        private readonly IAuthenticateUserLogic _authenticateUserLogic;
        private readonly IApiProcessFactory _apiProcessFactory;

        public ApiLogic(IAuthenticateUserLogic authenticateUserLogic, IApiProcessFactory apiProcessFactory)
        {
            _apiProcessFactory = apiProcessFactory;
            _authenticateUserLogic = authenticateUserLogic;
        }

        public async Task<TResponse> RunApiProcess<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest
            where TResponse : BaseResponse
        {
            request.AuthenticatedUser = _authenticateUserLogic.GetAuthenticatedUser(User);

            var apiProcess = _apiProcessFactory.GetApiProcess<TRequest, TResponse>();

            var validateResponse = await apiProcess.Validate(request).ConfigureAwait(false);

            if (!validateResponse.Success)
            {
                return validateResponse;
            }

            return await apiProcess.Execute(request).ConfigureAwait(false);
        }
    }
}
