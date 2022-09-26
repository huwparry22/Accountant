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

        public CreateLineItemProcess(IValidator<CreateLineItemRequest> validator)
        {
            _validator = validator;
        }

        public async Task<CreateLineItemResponse> Validate(CreateLineItemRequest request)
        {
            var validatorResponse = await _validator.ValidateAsync(request).ConfigureAwait(false);

            throw new NotImplementedException();
        }

        public async Task<CreateLineItemResponse> Execute(CreateLineItemRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
