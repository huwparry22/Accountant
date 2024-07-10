using Accountant.Data.Entities;

namespace Accountant.Data.EntityProviders
{
    public interface ISubLineItemProvider : IEntityProvider<SubLineItem>
    {
        Task<SubLineItem> GetBySubLineItemIdAsync(int subLineItemId);
    }
}
