using Accountant.API.Models;

namespace Accountant.API.Interfaces
{
    public interface IApiProcessFactory
    {
        IApiProcess<TRequest, TResponse> GetApiProcess<TRequest, TResponse>()
            where TRequest : BaseRequest
            where TResponse : BaseResponse;
    }
}
