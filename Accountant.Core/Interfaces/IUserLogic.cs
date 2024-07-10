using Accountant.API.Models.Requests.User;

namespace Accountant.Core.Interfaces
{
    public interface IUserLogic
    {
        Task<API.Models.User> GetUserByEmailAddress(string emailAddress);

        Task<API.Models.User> SaveUser(CreateUserRequest createUserRequest);
    }
}
