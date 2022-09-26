using Accountant.API.Models.Requests.LineItem;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.Validation.LineItem
{
    public class CreateLineItemValidation : AbstractValidator<CreateLineItemRequest>
    {
    }
}
