using Accountant.Data.Entities;

namespace Accountant.Data.EntityProvider
{
    public interface ILineItemProvider : IEntityProvider<LineItem>
    {
        Task<LineItem> GetByLineItemIdAsync(int entryId);
    }
}
