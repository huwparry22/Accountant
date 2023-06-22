using System.ComponentModel.DataAnnotations;

namespace Accountant.API.Models.Requests.User
{
    public class CreateUserRequest : BaseRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email address required")]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "First name required")]
        [EmailAddress]
        public string FirstName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name required")]
        [EmailAddress]
        public string LastName { get; set; } = string.Empty;
    }
}
