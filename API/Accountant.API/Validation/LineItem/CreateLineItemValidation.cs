﻿using Accountant.API.Models.Requests.LineItem;
using FluentValidation;

namespace Accountant.API.Validation.LineItem
{
    public class CreateLineItemValidation : AbstractValidator<CreateLineItemRequest>
    {
        public CreateLineItemValidation()
        {
            RuleFor(createLineItemRequest => createLineItemRequest.Description)
                .Must(ValidDescription)
                .WithMessage("Invalid description");
        }

        private static bool ValidDescription(string? description)
        {
            return !string.IsNullOrWhiteSpace(description);
        }
    }
}
