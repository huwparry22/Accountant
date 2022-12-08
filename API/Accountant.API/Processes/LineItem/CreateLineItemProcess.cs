using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.Core.Interfaces;
using FluentValidation;

namespace Accountant.API.Processes.LineItem
{
    public class CreateLineItemProcess : IApiProcess<CreateLineItemRequest, CreateLineItemResponse>
    {
        private readonly IValidator<CreateLineItemRequest> _validator;
        private readonly IValidationResultMapper _validationResultMapper;
        private readonly ILineItemLogic _lineItemLogic;

        public CreateLineItemProcess(
            IValidator<CreateLineItemRequest> validator, 
            IValidationResultMapper validationResultMapper,
            ILineItemLogic lineItemLogic)
        {
            _validator = validator;
            _validationResultMapper = validationResultMapper;
            _lineItemLogic = lineItemLogic;
        }

        public async Task<CreateLineItemResponse> Validate(CreateLineItemRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request).ConfigureAwait(false);

            return _validationResultMapper.MapToApiResponse<CreateLineItemResponse>(validationResult);
        }

        public async Task<CreateLineItemResponse> Execute(CreateLineItemRequest request)
        {
            var lineItemId = await _lineItemLogic.CreateLineItem(request).ConfigureAwait(false);

            return new CreateLineItemResponse
            {
                Success = true,
                LineItemId = lineItemId
            };
        }
    }
}
