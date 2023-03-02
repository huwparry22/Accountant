using System.ComponentModel.DataAnnotations;

namespace Accountant.API.Models.Requests.User
{
    public class GetUserRequest : BaseRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email address required")]
        public string? EmailAddress { get; set; }
    }
}
