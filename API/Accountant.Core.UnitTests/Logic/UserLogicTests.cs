using Accountant.API.Models.Requests.User;
using Accountant.Core.Interfaces;
using Accountant.Core.Logic;
using Accountant.Data.EntityProviders;
using FluentAssertions;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Accountant.Core.UnitTests.Logic
{
    public class UserLogicTests
    {
        private readonly Mock<IUserProvider> _mockUserProvider;
        private readonly Mock<IUserMapper> _mockUserMapper;

        private readonly UserLogic _objectToTest;

        public UserLogicTests()
        {
            _mockUserProvider = new Mock<IUserProvider>();
            _mockUserMapper = new Mock<IUserMapper>();

            _objectToTest = new UserLogic(_mockUserProvider.Object, _mockUserMapper.Object);
        }

        public class GetByUserEmailTests : UserLogicTests
        {
            private readonly string _emailAddress;
            private readonly Data.Entities.User _userEntity;
            private readonly API.Models.User _userModel;

            public GetByUserEmailTests() : base()
            {
                _emailAddress = "test@test.com";

                _userEntity = new Data.Entities.User();
                _userModel = new API.Models.User();

                _mockUserProvider
                    .Setup(x => x.GetByEmailAddressAsync(It.IsAny<string>()))
                    .ReturnsAsync(_userEntity);

                _mockUserMapper
                    .Setup(x => x.MapToModelUser(It.IsAny<Data.Entities.User>()))
                    .Returns(_userModel);
            }

            [Fact]
            public async Task CallsUserProviderGetByEmailAddress()
            {
                await _objectToTest.GetUserByEmailAddress(_emailAddress).ConfigureAwait(false);

                _mockUserProvider.Verify(x => x.GetByEmailAddressAsync(_emailAddress), Times.Once());
            }


            [Fact]
            public async Task CallsUserMapperMapToModelUser()
            {
                await _objectToTest.GetUserByEmailAddress(_emailAddress).ConfigureAwait(false);

                _mockUserMapper.Verify(x => x.MapToModelUser(_userEntity), Times.Once());
            }

            [Fact]
            public async Task ReturnsUserModel()
            {
                var actual = await _objectToTest.GetUserByEmailAddress(_emailAddress).ConfigureAwait(false);

                actual.Should().Be(_userModel);
            }
        }

        public class SaveUserTests : UserLogicTests
        {
            private readonly CreateUserRequest _createUserRequest;

            private readonly Data.Entities.User _userEntity;
            private readonly Data.Entities.User _saveUserEntity;
            private readonly API.Models.User _userModel;

            public SaveUserTests() : base()
            {
                _createUserRequest = new CreateUserRequest();
                _userEntity = new Data.Entities.User();
                _saveUserEntity = new Data.Entities.User();
                _userModel = new API.Models.User();

                _mockUserMapper
                    .Setup(x => x.MapToEntityUser(It.IsAny<CreateUserRequest>()))
                    .Returns(_userEntity);

                _mockUserProvider
                    .Setup(x => x.SaveAsync(It.IsAny<Data.Entities.User>()))
                    .ReturnsAsync(_saveUserEntity);

                _mockUserMapper
                    .Setup(x => x.MapToModelUser(It.IsAny<Data.Entities.User>()))
                    .Returns(_userModel);
            }

            [Fact]
            public async Task CallsUserMapperMapToEntityUser()
            {
                await _objectToTest.SaveUser(_createUserRequest).ConfigureAwait(false);

                _mockUserMapper.Verify(x => x.MapToEntityUser(_createUserRequest), Times.Once());
            }

            [Fact]
            public async Task CallsUserProviderSaveAsync()
            {
                await _objectToTest.SaveUser(_createUserRequest).ConfigureAwait(false);

                _mockUserProvider.Verify(x => x.SaveAsync(_userEntity), Times.Once());
            }

            [Fact]
            public async Task CallsUserMapperMapToModelUser()
            {
                await _objectToTest.SaveUser(_createUserRequest).ConfigureAwait(false);

                _mockUserMapper.Verify(x => x.MapToModelUser(_saveUserEntity), Times.Once());
            }

            [Fact]
            public async Task ReturnsUserModel()
            {
                var actual = await _objectToTest.SaveUser(_createUserRequest).ConfigureAwait(false);

                actual.Should().Be(_userModel);
            }
        }
    }
}
