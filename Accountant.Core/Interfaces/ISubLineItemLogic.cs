using Accountant.API.Models.Requests.SubLineItem;

namespace Accountant.Core.Interfaces
{
    public interface ISubLineItemLogic
    {
        Task<int> CreateSubLineItem(CreateSubLineItemRequest createSubLineItemRequest);
    }
}
