using Accountant.API.Models.Requests.LineItem;
using FluentValidation;

namespace Accountant.API.Validation.LineItem
{
    public class CreateLineItemValidation : AbstractValidator<CreateLineItemRequest>
    {
        public CreateLineItemValidation()
        {
            RuleFor(createLineItemRequest => createLineItemRequest.Description)
                .Must(description => ValidDescription(description))
                .WithMessage("Invalid description");
        }

        public bool ValidDescription(string description)
        {
            return !string.IsNullOrWhiteSpace(description);
        }
    }
}
