using Accountant.API.Interfaces;
using Accountant.API.Models;
using Accountant.API.WebAPI.Interfaces;

namespace Accountant.API.WebAPI.Logic
{
    public class ApiProcessLogic : IApiProcessLogic
    {
        private readonly IApiProcessFactory _apiProcessFactory;

        public ApiProcessLogic(IApiProcessFactory apiProcessFactory)
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
