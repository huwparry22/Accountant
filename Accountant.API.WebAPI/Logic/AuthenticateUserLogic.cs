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

        public async Task<(BaseResponse Response, User? User)> GetAuthenticatedUser(ClaimsPrincipal user)
        {
            var getUserResponse = await GetUser(user).ConfigureAwait(false);

            if (!getUserResponse.Success)
            {
                return (getUserResponse, default);
            }

            if (getUserResponse.Success && getUserResponse.User != null)
            {
                return (getUserResponse, getUserResponse.User);
            }
            
            var createUserResponse = await CreateUser(user).ConfigureAwait(false);

            return (createUserResponse, createUserResponse.User);
        }

        private async Task<GetUserResponse> GetUser(ClaimsPrincipal user)
        {
            var getUserRequest = new GetUserRequest
            {
                EmailAddress = user.FindFirstValue("Emails")
            };

            return await _apiProcessLogic.RunApiProcess<GetUserRequest, GetUserResponse>(getUserRequest).ConfigureAwait(false);
        }

        private async Task<CreateUserResponse> CreateUser(ClaimsPrincipal user)
        {
            var createUserRequest = new CreateUserRequest
            {
                EmailAddress = user.FindFirstValue("Emails")
                //ToDo
            };

            return await _apiProcessLogic.RunApiProcess<CreateUserRequest, CreateUserResponse>(createUserRequest).ConfigureAwait(false);
        }
    }
}
