using Accountant.API.Models.Requests.LineItem;

namespace Accountant.Core.Interfaces
{
    public interface ILineItemLogic
    {
        Task<int> CreateLineItem(CreateLineItemRequest request);
    }
}
