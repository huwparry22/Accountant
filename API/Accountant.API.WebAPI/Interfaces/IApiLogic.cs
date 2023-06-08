using Accountant.API.Models;

namespace Accountant.API.WebAPI.Interfaces
{
    public interface IApiLogic
    {
        Task<TResponse> AuthenticateAndRunApiProcess<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest
            where TResponse : BaseResponse;

        Task<TResponse> RunApiProcess<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest
            where TResponse : BaseResponse;
    }
}
