using Accountant.API.Models;

namespace Accountant.API.Interfaces
{
    public interface IApiProcess<Request, Response>
        where Request : BaseRequest
        where Response : BaseResponse
    {
        Response Validate(Request request);

        Response Execute(Request request);
    }
}
