using Accountant.Core.Mappers;
using FluentAssertions;
using Xunit;

namespace Accountant.Core.UnitTests.Mappers
{
    public class UserMapperTests
    {
        private readonly UserMapper _objectToTest;

        public UserMapperTests()
        {
            _objectToTest = new UserMapper();
        }

        [Theory]
        [ClassData(typeof(UserMapperMapToModelUserTestData))]
        public void MapToModelUser(Data.Entities.User parameter, API.Models.User expected)
        {
            var actual = _objectToTest.MapToModelUser(parameter);

            actual.Should().BeEquivalentTo(expected);
        }


        public class UserMapperMapToModelUserTestData : TheoryData<Data.Entities.User, API.Models.User?>
        {
            public UserMapperMapToModelUserTestData()
            {
                Add(null, default);

                Add(
                    new Data.Entities.User
                    {
                        UserId = 99,
                        EmailAddress = "test@test.com"
                    },
                    new API.Models.User
                    {
                        UserId = 99,
                        EmailAddress = "test@test.com"
                    });
            }
        }
    }
}
