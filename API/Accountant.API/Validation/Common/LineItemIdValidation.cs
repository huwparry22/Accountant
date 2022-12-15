using Accountant.API.Models.Interfaces;
using Accountant.Core.Interfaces;
using FluentValidation;

namespace Accountant.API.Validation.Common
{
    public class LineItemIdValidation : AbstractValidator<ILineItemId>
    {
        private readonly ILineItemLogic _lineItemLogic;

        public LineItemIdValidation(ILineItemLogic lineItemLogic)
        {
            _lineItemLogic = lineItemLogic;

            RuleFor(request => request.LineItemId)
                .NotEmpty()
                //User validation
                .MustAsync((lineItemId, cancellationToken) => ValidLineItemId(lineItemId));
                //LineItemId valid for user
        }

        private async Task<bool> ValidLineItemId(int? lineItemId)
        {
            var lineItem = await _lineItemLogic.GetLineItemByLineItemId(lineItemId.Value).ConfigureAwait(false);

            return lineItem != null && lineItem.LineItemId == lineItemId.Value;
        }
    }
}
