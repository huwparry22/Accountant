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
        public CreateSubLineItemValidation()
        {

        }
    }
}
