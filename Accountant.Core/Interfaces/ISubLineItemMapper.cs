using Accountant.API.Models.Requests.SubLineItem;
using Accountant.Data.Entities;

namespace Accountant.Core.Interfaces
{
    public interface ISubLineItemMapper
    {
        SubLineItem GetSubLineItem(CreateSubLineItemRequest subLineItemRequest);
    }
}
