namespace Accountant.Core.Interfaces
{
    public interface IUserLogic
    {
        Task<API.Models.User> GetUserByEmailAddress(string emailAddress);
    }
}
