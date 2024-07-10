using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.WebAPI.Interfaces;
using Accountant.API.WebAPI.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Accountant.API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LineItemController : ApiLogic
    {
        public LineItemController(IApiLogicAggregator apiLogicAggregator) : base(apiLogicAggregator) { }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateLineItemResponse>> Create(CreateLineItemRequest createLineItemRequest)
        {
            return await RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(createLineItemRequest).ConfigureAwait(false);
        }
    }
}
