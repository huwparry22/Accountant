using Accountant.Data.Entities;

namespace Accountant.Data.EntityProvider
{
    public interface IUserProvider : IEntityProvider<User>
    {
        Task<User> GetByUserIdAsync(int userId);
    }
}
