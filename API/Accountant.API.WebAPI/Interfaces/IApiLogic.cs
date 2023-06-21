using Accountant.API.Models;
using System.Security.Claims;

namespace Accountant.API.WebAPI.Interfaces
{
    public interface IApiLogic
    {
        Task<TResponse> RunApiProcess<TRequest, TResponse>(TRequest request, ClaimsPrincipal user)
            where TRequest : BaseRequest
            where TResponse : BaseResponse;
    }
}
