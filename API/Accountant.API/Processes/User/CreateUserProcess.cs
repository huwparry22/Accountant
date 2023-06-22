using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.User;
using Accountant.API.Models.Responses.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.Processes.User
{
    public class CreateUserProcess : IApiProcess<CreateUserRequest, CreateUserResponse>
    {
        public Task<CreateUserResponse> Validate(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<CreateUserResponse> Execute(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
