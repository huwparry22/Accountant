using Accountant.API.Models.Requests.User;
using Accountant.API.Validation.User;
using FluentValidation.TestHelper;

namespace Accountant.API.UnitTests.Validation.User
{
    public class GetUserValidationTests
    {
        private readonly GetUserValidation _objectToTest;

        public GetUserValidationTests()
        {
            _objectToTest = new GetUserValidation();
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("test", false)]
        [InlineData("@test", false)]
        [InlineData("test@", false)]
        [InlineData("t@t", true)]
        [InlineData("test@test", true)]
        [InlineData("test@test.com", true)]
        public void Validate_EmailAddress(string emailAddress, bool isValid)
        {
            var getUserRequest = new GetUserRequest
            {
                EmailAddress = emailAddress
            };

            var actual = _objectToTest.TestValidate(getUserRequest);

            actual.IsValid.Should().Be(isValid);

            if (!isValid)
            {
                actual
                    .ShouldHaveValidationErrorFor(req => req.EmailAddress)
                    .WithErrorMessage("Invalid email address");
            }
        }
    }
}
