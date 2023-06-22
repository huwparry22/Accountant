using Accountant.API.Models.Requests.User;
using FluentValidation;

namespace Accountant.API.Validation.User
{
    public class CreateUserValidation : AbstractValidator<CreateUserRequest>
    {
        private const string INVALID_EMAIL_ADDRESS_MESSAGE = "Invalid email address";
        private const string INVALID_FIRST_NAME_MESSAGE = "Invalid first name";
        private const string INVALID_LAST_NAME_MESSAGE = "Invalid last name";

        public CreateUserValidation()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(createUserRequest => createUserRequest.EmailAddress)
                .NotEmpty()
                .WithMessage(INVALID_EMAIL_ADDRESS_MESSAGE)
                .EmailAddress()
                .WithMessage(INVALID_EMAIL_ADDRESS_MESSAGE);

            RuleFor(createUserRequest => createUserRequest.FirstName)
                .NotEmpty()
                .WithMessage(INVALID_FIRST_NAME_MESSAGE);

            RuleFor(createUserRequest => createUserRequest.LastName)
                .NotEmpty()
                .WithMessage(INVALID_LAST_NAME_MESSAGE);
        }
    }
}
