using Accountant.Data.Entities;

namespace Accountant.Data.EntityProviders
{
    public interface IUserProvider : IEntityProvider<User>
    {
        Task<User> GetByUserIdAsync(int userId);

        Task<User> GetByEmailAddress(string emailAddress);
    }
}
