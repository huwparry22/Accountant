using Accountant.API.Models.Requests.User;
using Accountant.Core.Interfaces;
using Accountant.Data.EntityProviders;

namespace Accountant.Core.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserProvider _userProvider;
        private readonly IUserMapper _userMapper;

        public UserLogic(IUserProvider userProvider, IUserMapper userMapper)
        {
            _userProvider = userProvider;
            _userMapper = userMapper;
        }

        public async Task<API.Models.User> GetUserByEmailAddress(string emailAddress)
        {
            var user = await _userProvider.GetByEmailAddressAsync(emailAddress).ConfigureAwait(false);

            return _userMapper.MapToModelUser(user);
        }

        public async Task<Data.Entities.User> SaveUser(CreateUserRequest createUserRequest)
        {
            var user = _userMapper.MapToEntityUser(createUserRequest);

            return await _userProvider.SaveAsync(user).ConfigureAwait(false);
        }
    }
}
