using Accountant.API.Models.Requests.User;
using Accountant.API.Validation.User;
using FluentValidation.TestHelper;

namespace Accountant.API.UnitTests.Validation.User
{
    public class CreateUserValidationTests
    {
        private readonly CreateUserValidation _objectToTest;

        public CreateUserValidationTests()
        {
            _objectToTest = new CreateUserValidation();
        }

        [Theory]
        [ClassData(typeof(CreateUserValidationTestData))]
        public void ValidationTests<TProperty>(CreateUserRequest createUserRequest, bool isValid, string errorValidationPropertyName, string errorMessage)
        {
            var actual = _objectToTest.TestValidate(createUserRequest);

            actual.IsValid.Should().Be(isValid);

            if (!isValid)
            {
                actual
                    .ShouldHaveValidationErrorFor(errorValidationPropertyName)
                    .WithErrorMessage(errorMessage);
            }
        }

        public class CreateUserValidationTestData : TheoryData<CreateUserRequest, bool, string, string>
        {
            public CreateUserValidationTestData()
            {
                Add(
                    new CreateUserRequest
                    {
                        EmailAddress = "test@test.com",
                        FirstName = "testFirstName",
                        LastName = "testLastName"
                    },
                    true,
                    string.Empty,
                    string.Empty
                  );

                Add(
                    new CreateUserRequest
                    {
                        EmailAddress = string.Empty
                    },
                    false,
                    nameof(CreateUserRequest.EmailAddress),
                    "Invalid email address"
                    );

                Add(
                    new CreateUserRequest
                    {
                        EmailAddress = "test"
                    },
                    false,
                    nameof(CreateUserRequest.EmailAddress),
                    "Invalid email address"
                    );

                Add(
                    new CreateUserRequest
                    {
                        EmailAddress = "test@test.com",
                        FirstName = string.Empty
                    },
                    false,
                    nameof(CreateUserRequest.FirstName),
                    "Invalid first name"
                    );

                Add(
                    new CreateUserRequest
                    {
                        EmailAddress = "test@test.com",
                        FirstName = "testFirstName",
                        LastName = string.Empty
                    },
                    false,
                    nameof(CreateUserRequest.LastName),
                    "Invalid last name"
                    );
            }
        }
    }
}
