using Accountant.API.Models;

namespace Accountant.API.WebAPI.Interfaces
{
    public interface IApiProcessLogic
    {
        Task<TResponse> RunApiProcess<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest
            where TResponse : BaseResponse;
    }
}
