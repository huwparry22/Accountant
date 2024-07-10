using Accountant.API.Models.Requests.User;
using FluentValidation;

namespace Accountant.API.Validation.User
{
    public class GetUserValidation : AbstractValidator<GetUserRequest>
    {
        public GetUserValidation()
        {
            var invalidEmailAddressMessage = "Invalid email address";

            RuleFor(getUserRequest => getUserRequest.EmailAddress)
                .NotEmpty()
                .WithMessage(invalidEmailAddressMessage)
                .EmailAddress()
                .WithMessage(invalidEmailAddressMessage);
        }        
    }
}
