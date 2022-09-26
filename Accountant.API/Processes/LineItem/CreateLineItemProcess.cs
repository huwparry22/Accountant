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

        public CreateLineItemResponse Validate(CreateLineItemRequest request)
        {
            throw new NotImplementedException();
        }

        public CreateLineItemResponse Execute(CreateLineItemRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
