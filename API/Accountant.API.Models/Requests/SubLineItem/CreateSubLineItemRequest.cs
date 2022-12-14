using System.ComponentModel.DataAnnotations;

namespace Accountant.API.Models.Requests.SubLineItem
{
    public  class CreateSubLineItemRequest : BaseRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "LineItemId required")]
        public int? LineItemId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "SubLineItemType required")]
        public SubLineItemType? SubLineItemType { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Description required")]
        public string? Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Amount required")]
        public decimal? Amount { get; set; }
    }
}
