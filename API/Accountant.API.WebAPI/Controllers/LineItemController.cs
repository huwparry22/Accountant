using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Microsoft.AspNetCore.Mvc;

namespace Accountant.API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineItemController : ControllerBase
    {
        private readonly IApiLogic _apiLogic;

        public LineItemController(IApiLogic apiLogic)
        {
            _apiLogic = apiLogic;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateLineItemResponse>> Create(CreateLineItemRequest createLineItemRequest)
        {
            return await _apiLogic.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(createLineItemRequest).ConfigureAwait(false);
        }
    }
}
