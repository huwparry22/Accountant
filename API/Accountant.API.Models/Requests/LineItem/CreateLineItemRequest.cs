using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.Models.Requests.LineItem
{
    public class CreateLineItemRequest : BaseRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description required")]
        public string? Description { get; set; }
    }
}
