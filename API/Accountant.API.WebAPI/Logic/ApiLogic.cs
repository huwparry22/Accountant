using Accountant.API.Interfaces;
using Accountant.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Accountant.API.WebAPI.Logic
{
    public class ApiLogic : ControllerBase, IApiLogic
    {
        private readonly IApiProcessFactory _apiProcessFactory;

        public ApiLogic(IApiProcessFactory apiProcessFactory)
        {
            _apiProcessFactory = apiProcessFactory;
        }

        public async Task<TResponse> RunApiProcess<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest
            where TResponse : BaseResponse
        {
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
