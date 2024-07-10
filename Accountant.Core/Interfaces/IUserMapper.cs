using Accountant.API.Models.Requests.User;

namespace Accountant.Core.Interfaces
{
    public interface IUserMapper
    {
        API.Models.User? MapToModelUser(Data.Entities.User user);

        Data.Entities.User MapToEntityUser(CreateUserRequest createUserRequest);
    }
}
