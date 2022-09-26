using Accountant.API.Models;

namespace Accountant.API.Interfaces
{
    public interface IApiProcess<Request, Response>
        where Request : BaseRequest
        where Response : BaseResponse
    {
        Task<Response> Validate(Request request);

        Task<Response> Execute(Request request);
    }
}
