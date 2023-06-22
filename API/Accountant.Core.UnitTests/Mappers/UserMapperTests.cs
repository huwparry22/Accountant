using Accountant.API.Models.Requests.User;
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

        public class MapToModelUserTests : UserMapperTests
        {
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

        public class MapToEntityUserTests : UserMapperTests
        {
            [Theory]
            [ClassData(typeof(MapToEntityUserTestData))]
            public void MapToEntityUser(CreateUserRequest parameter, Data.Entities.User expected)
            {
                var actual = _objectToTest.MapToEntityUser(parameter);

                actual.Should().BeEquivalentTo(expected);
            }

            public class MapToEntityUserTestData : TheoryData<CreateUserRequest, Data.Entities.User>
            {
                public MapToEntityUserTestData()
                {
                    Add(
                        new CreateUserRequest
                        {
                            EmailAddress = "test@test.com",
                            FirstName = "testFirstName",
                            LastName = "testLastName"
                        },
                        new Data.Entities.User
                        {
                            EmailAddress = "test@test.com",
                            FirstName = "testFirstName",
                            LastName = "testLastName"
                        });
                }
            }
        }
    }
}
