using Accountant.API.Models.Requests.SubLineItem;
using Accountant.API.Models.Responses.SubLineItem;
using Accountant.API.WebAPI.Interfaces;
using Accountant.API.WebAPI.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Accountant.API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubLineItemController : ApiLogic
    {
        public SubLineItemController(IApiLogicAggregator apiLogicAggregator) : base(apiLogicAggregator) { }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateSubLineItemResponse>> Create(CreateSubLineItemRequest createSubLineItemRequest)
        {
            return await RunApiProcess<CreateSubLineItemRequest, CreateSubLineItemResponse>(createSubLineItemRequest).ConfigureAwait(false);
        }
    }
}
