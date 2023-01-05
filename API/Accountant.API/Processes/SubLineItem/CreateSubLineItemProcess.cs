using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.SubLineItem;
using Accountant.API.Models.Responses.SubLineItem;
using Accountant.Core.Interfaces;
using FluentValidation;

namespace Accountant.API.Processes.SubLineItem
{
    public class CreateSubLineItemProcess : IApiProcess<CreateSubLineItemRequest, CreateSubLineItemResponse>
    {
        private readonly IValidator<CreateSubLineItemRequest> _validator;
        private readonly IValidationResultMapper _validationResultMapper;
        private readonly ISubLineItemLogic _subLineItemLogic;

        public CreateSubLineItemProcess(IValidator<CreateSubLineItemRequest> validator, IValidationResultMapper validationResultMapper, ISubLineItemLogic subLineItemLogic)
        {
            _validator = validator;
            _validationResultMapper = validationResultMapper;
            _subLineItemLogic = subLineItemLogic;
        }

        public async Task<CreateSubLineItemResponse> Validate(CreateSubLineItemRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request).ConfigureAwait(false);

            return _validationResultMapper.MapToApiResponse<CreateSubLineItemResponse>(validationResult);
        }

        public async Task<CreateSubLineItemResponse> Execute(CreateSubLineItemRequest request)
        {
            var subLineItemId = await _subLineItemLogic.CreateSubLineItem(request).ConfigureAwait(false);

            return new CreateSubLineItemResponse
            {
                Success = true,
                SubLineItemId = subLineItemId
            };
        }
    }
}
