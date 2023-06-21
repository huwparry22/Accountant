using Accountant.API.Interfaces;
using Accountant.API.Models;
using Accountant.API.Models.Requests.User;
using Accountant.API.Models.Responses.User;
using Accountant.API.WebAPI.Interfaces;
using System.Security.Claims;

namespace Accountant.API.WebAPI.Logic
{
    public class AuthenticateUserLogic : IAuthenticateUserLogic
    {
        private IApiProcessLogic _apiProcessLogic;

        public AuthenticateUserLogic(IApiProcessLogic apiProcessLogic)
        {
            _apiProcessLogic = apiProcessLogic;
        }

        public async Task<User> GetAuthenticatedUser(ClaimsPrincipal user)
        {
            var getUserRequest = new GetUserRequest
            {
                EmailAddress = ""   //user.
            };

            var getUserResponse = await _apiProcessLogic.RunApiProcess<GetUserRequest, GetUserResponse>(getUserRequest).ConfigureAwait(false);

            return null;
        }
    }
}
