using System.ComponentModel.DataAnnotations;

namespace Accountant.API.Models.Requests.LineItem
{
    public class CreateLineItemRequest : BaseRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description required")]
        public string? Description { get; set; }
    }
}
