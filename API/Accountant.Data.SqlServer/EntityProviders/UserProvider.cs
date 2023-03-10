using Accountant.Data.Entities;
using Accountant.Data.EntityProviders;
using Accountant.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Accountant.Data.SqlServer.EntityProviders
{
    public class UserProvider : EntityProvider<User>, IUserProvider
    {
        public UserProvider(AccountantContext accountantContext) : base(accountantContext) { }

        public async Task<User> GetByUserIdAsync(int userId)
        {
            return await _accountantContext
                .Users
                .SingleOrDefaultAsync(u => u.UserId == userId)
                .ConfigureAwait(false);
        }

        public async Task<User> GetByEmailAddress(string emailAddress)
        {
            return await _accountantContext
                .Users
                .SingleOrDefaultAsync(u => u.EmailAddress == emailAddress)
                .ConfigureAwait(false);
        }
    }
}
