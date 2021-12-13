using Accountant.Data.Entities.Enums;

namespace Accountant.Data.Entities
{
    public class EntryItem
    {
        public int EntryItemId { get; set; }

        public int EntryId { get; set; }

        public EntryItemType EntryItemTypeId { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }
    }
}
