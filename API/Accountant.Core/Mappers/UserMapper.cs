using Accountant.API.Models.Requests.User;
using Accountant.Core.Interfaces;
using Accountant.Data.Entities;

namespace Accountant.Core.Mappers
{
    public class UserMapper : IUserMapper
    {
        public API.Models.User? MapToModelUser(Data.Entities.User user)
        {
            if (user == null)
                return default;

            return new API.Models.User
            {
                UserId = user.UserId,
                EmailAddress = user.EmailAddress
            };
        }

        public User MapToEntityUser(CreateUserRequest createUserRequest)
        {
            return new User
            {
                EmailAddress = createUserRequest.EmailAddress,
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName
            };
        }
    }
}
