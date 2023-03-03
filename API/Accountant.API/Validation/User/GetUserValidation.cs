using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Requests.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Accountant.API.Validation.User
{
    public class GetUserValidation : AbstractValidator<GetUserRequest>
    {
        public GetUserValidation()
        {
            RuleFor(getUserRequest => getUserRequest.EmailAddress)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Invalid email address");
        }        
    }
}
