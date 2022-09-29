using Accountant.Data.Entities;

namespace Accountant.Data.EntityProviders
{
    public interface ILineItemProvider : IEntityProvider<LineItem>
    {
        Task<LineItem> GetByLineItemIdAsync(int lineItemId);
    }
}
