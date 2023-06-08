using Accountant.API.Models;
using System.Security.Claims;

namespace Accountant.API.WebAPI.Interfaces
{
    public interface IAuthenticateUserLogic
    {
        Task<User> GetAuthenticatedUser(ClaimsPrincipal user);
    }
}
