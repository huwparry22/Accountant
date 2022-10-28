using Accountant.API.Models;

namespace Accountant.API.WebAPI
{
    public interface IApiLogic
    {
        Task<TResponse> RunApiProcess<TRequest, TResponse>(TRequest request)
            where TRequest : BaseRequest
            where TResponse : BaseResponse;
    }
}
