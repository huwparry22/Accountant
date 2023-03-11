namespace Accountant.Core.Interfaces
{
    public interface IUserMapper
    {
        API.Models.User MapToModelUser(Data.Entities.User user);
    }
}
