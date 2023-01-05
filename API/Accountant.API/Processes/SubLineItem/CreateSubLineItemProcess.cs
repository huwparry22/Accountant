using Accountant.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accountant.API.Models.Requests.SubLineItem;
using Accountant.API.Models.Responses.SubLineItem;
using FluentValidation;
using Accountant.Core.Interfaces;

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

        public Task<CreateSubLineItemResponse> Validate(CreateSubLineItemRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CreateSubLineItemResponse> Execute(CreateSubLineItemRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
