using Accountant.API.Models.Requests.LineItem;
using Accountant.Data.Entities;

namespace Accountant.Core.Interfaces
{
    public interface ILineItemMapper
    {
        LineItem MapToLineItem(CreateLineItemRequest createLineItemRequest);
    }
}
