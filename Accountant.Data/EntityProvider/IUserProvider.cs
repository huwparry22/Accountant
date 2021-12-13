using Accountant.Data.Entities;

namespace Accountant.Data.EntityProvider
{
    public interface IUserProvider : IEntityProvider<User>
    {
        Task<User> GetByUserId(int userId);
    }
}
