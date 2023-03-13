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
    }
}
