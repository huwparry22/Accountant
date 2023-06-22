using Accountant.Core.Interfaces;

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
    }
}
