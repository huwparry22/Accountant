using Accountant.Data.Entities;

namespace Accountant.Data.EntityProvider
{
    public interface IEntryProvider : IEntityProvider<Entry>
    {
        Task<Entry> GetByEntryIdAsync(int entryId);
    }
}
