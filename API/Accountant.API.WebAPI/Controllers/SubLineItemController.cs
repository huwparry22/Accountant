using Accountant.API.Models.Requests.SubLineItem;
using Accountant.API.Models.Responses.SubLineItem;
using Accountant.API.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Accountant.API.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubLineItemController : ControllerBase
    {
        private readonly IApiLogic _apiLogic;

        public SubLineItemController(IApiLogic apiLogic)
        {
            _apiLogic = apiLogic;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CreateSubLineItemResponse>> Create(CreateSubLineItemRequest createSubLineItemRequest)
        {
            return await _apiLogic.RunApiProcess<CreateSubLineItemRequest, CreateSubLineItemResponse>(createSubLineItemRequest, User).ConfigureAwait(false);
        }
    }
}
