using Accountant.API.Models;
using Accountant.API.WebAPI.Interfaces;
using System.Security.Claims;

namespace Accountant.API.WebAPI.Logic
{
    public class AuthenticateUserLogic : IAuthenticateUserLogic
    {
        public User GetAuthenticatedUser(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
    }
}
