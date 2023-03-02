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
    public class GetUserProcess : IApiProcess<GetUserRequest, GetUserResponse>
    {
        public Task<GetUserResponse> Validate(GetUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserResponse> Execute(GetUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
