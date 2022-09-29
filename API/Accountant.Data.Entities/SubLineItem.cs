using Accountant.Data.Entities.Enums;

namespace Accountant.Data.Entities
{
    public class SubLineItem
    {
        public int SubLineItemId { get; set; }

        public int LineItemId { get; set; }

        public SubLineItemType SubLineItemTypeId { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }
    }
}
