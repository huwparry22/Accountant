using Accountant.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accountant.API.Models.Requests.SubLineItem;
using Accountant.API.Models.Responses.SubLineItem;

namespace Accountant.API.Processes.SubLineItem
{
    public class CreateSubLineItemProcess : IApiProcess<CreateSubLineItemRequest, CreateSubLineItemResponse>
    {
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
