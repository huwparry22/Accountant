using Accountant.API.Models;
using System.Security.Claims;

namespace Accountant.API.WebAPI.Interfaces
{
    public interface IAuthenticateUserLogic
    {
        User GetAuthenticatedUser(ClaimsPrincipal user);
    }
}
