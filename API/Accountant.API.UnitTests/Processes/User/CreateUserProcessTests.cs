using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.User;
using Accountant.API.Models.Responses.User;
using Accountant.API.Processes.User;
using Accountant.Core.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.UnitTests.Processes.User
{
    public class CreateUserProcessTests
    {
        private readonly Mock<IValidator<CreateUserRequest>> _mockCreateUserRequestValidator;
        private readonly Mock<IValidationResultMapper> _mockValidationResultMapper;
        private readonly Mock<IUserLogic> _mockUserLogic;

        private readonly CreateUserProcess _objectToTest;

        public CreateUserProcessTests()
        {
            _mockCreateUserRequestValidator = new Mock<IValidator<CreateUserRequest>>();
            _mockValidationResultMapper = new Mock<IValidationResultMapper>();
            _mockUserLogic = new Mock<IUserLogic>();

            _objectToTest = new CreateUserProcess(_mockCreateUserRequestValidator.Object, _mockValidationResultMapper.Object, _mockUserLogic.Object);
        }

        public class ValidateTests : CreateUserProcessTests
        {
            private readonly CreateUserRequest _request;
            private readonly ValidationResult _validationResult;
            private readonly CreateUserResponse _response;

            public ValidateTests() : base()
            {
                _request = new CreateUserRequest();
                _validationResult = new ValidationResult();
                _response = new CreateUserResponse();

                _mockCreateUserRequestValidator
                    .Setup(x => x.ValidateAsync(It.IsAny<CreateUserRequest>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(_validationResult);

                _mockValidationResultMapper
                    .Setup(x => x.MapToApiResponse<CreateUserResponse>(It.IsAny<ValidationResult>()))
                    .Returns(_response);
            }

            [Fact]
            public async Task CallsValidatorValidateAsync()
            {
                var resut = await _objectToTest.Validate(_request).ConfigureAwait(false);

                _mockCreateUserRequestValidator.Verify(x => x.ValidateAsync(_request, It.IsAny<CancellationToken>()), Times.Once());
            }

            [Fact]
            public async Task CallsValidationResultMapperMapToApiResponse()
            {
                var result = await _objectToTest.Validate(_request).ConfigureAwait(false);

                _mockValidationResultMapper.Verify(x => x.MapToApiResponse<CreateUserResponse>(_validationResult), Times.Once());
            }

            [Fact]
            public async Task ReturnsGetUserResponse()
            {
                var result = await _objectToTest.Validate(_request).ConfigureAwait(false);

                result.Should().Be(_response);
            }
        }

        public class ExecuteTests : CreateUserProcessTests
        {
            private readonly CreateUserRequest _request;
            private readonly Models.User _userModel;

            public ExecuteTests() : base()
            {
                _request = new CreateUserRequest
                {
                    EmailAddress = "test@test.com"
                };

                _userModel = new Models.User
                {
                    UserId = 99,
                    EmailAddress = "test@test.com"
                };

                _mockUserLogic
                    .Setup(x => x.SaveUser(It.IsAny<CreateUserRequest>()))
                    .ReturnsAsync(_userModel);
            }

            [Fact]
            public async Task CallsUserLogicSaveUser()
            {
                await _objectToTest.Execute(_request).ConfigureAwait(false);

                _mockUserLogic.Verify(x => x.SaveUser(_request), Times.Once());
            }

            [Fact]
            public async Task ReturnsUserModelInResponse()
            {
                var actual = await _objectToTest.Execute(_request).ConfigureAwait(false);

                actual.Success.Should().BeTrue();
                actual.User.Should().Be(_userModel);
            }
        }
    }
}
