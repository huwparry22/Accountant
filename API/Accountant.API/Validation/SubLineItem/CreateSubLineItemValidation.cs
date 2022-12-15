using Accountant.API.Models.Interfaces;
using Accountant.API.Models.Requests.SubLineItem;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.Validation.SubLineItem
{
    public class CreateSubLineItemValidation : AbstractValidator<CreateSubLineItemRequest>
    {
        private readonly IValidator<ILineItemId> _lineItemIdValidation;

        public CreateSubLineItemValidation(IValidator<ILineItemId> lineItemIdValidation)
        {
            _lineItemIdValidation = lineItemIdValidation;

            this.CascadeMode = CascadeMode.Stop;

            Include(_lineItemIdValidation);

            RuleFor(createSubLineItemRequest => createSubLineItemRequest.Amount)
                .NotEmpty()
                .WithMessage("Invalid amount - no value provided")
                .GreaterThan(0)
                .WithMessage("Invalid amount - invalid value");

            RuleFor(createSubLineItemRequest => createSubLineItemRequest.Description)
                .NotEmpty()
                .WithMessage("Invalid Description - no value provided");

            RuleFor(createSubLineItemRequest => createSubLineItemRequest.SubLineItemType)
                .IsInEnum()
                .WithMessage("Invalid SubLineItemType - invalid value");
        }
    }
}
