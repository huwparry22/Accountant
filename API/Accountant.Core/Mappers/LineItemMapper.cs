using Accountant.API.Models.Requests.LineItem;
using Accountant.Core.Interfaces;
using Accountant.Data.Entities;

namespace Accountant.Core.Mappers
{
    public class LineItemMapper : ILineItemMapper
    {
        public LineItem MapToLineItem(CreateLineItemRequest createLineItemRequest)
        {
            if (createLineItemRequest == null)
                throw new ArgumentNullException(nameof(createLineItemRequest));

            return new LineItem
            {
                Created = DateTime.UtcNow,
                Description = createLineItemRequest.Description
                //UserId
            };
        }
    }
}
