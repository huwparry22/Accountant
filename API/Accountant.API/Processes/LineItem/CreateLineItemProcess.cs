using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.Processes.LineItem
{
    public class CreateLineItemProcess : IApiProcess<CreateLineItemRequest, CreateLineItemResponse>
    {
        private readonly IValidator<CreateLineItemRequest> _validator;
        private readonly IValidationResultMapper _validationResultMapper;

        public CreateLineItemProcess(IValidator<CreateLineItemRequest> validator, IValidationResultMapper validationResultMapper)
        {
            _validator = validator;
            _validationResultMapper = validationResultMapper;
        }

        public async Task<CreateLineItemResponse> Validate(CreateLineItemRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request).ConfigureAwait(false);

            return _validationResultMapper.MapToApiResponse<CreateLineItemResponse>(validationResult);
        }

        public async Task<CreateLineItemResponse> Execute(CreateLineItemRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
