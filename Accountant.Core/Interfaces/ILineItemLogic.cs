using Accountant.API.Models.Requests.LineItem;
using Accountant.Data.Entities;

namespace Accountant.Core.Interfaces
{
    public interface ILineItemLogic
    {
        Task<int> CreateLineItem(CreateLineItemRequest request);

        Task<LineItem> GetLineItemByLineItemId(int lineItemId);
    }
}
