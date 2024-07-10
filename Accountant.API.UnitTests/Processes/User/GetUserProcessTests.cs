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
    public class GetUserProcessTests
    {
        private readonly Mock<IValidator<GetUserRequest>> _mockGetUserValidation;
        private readonly Mock<IValidationResultMapper> _mockValidationResultMapper;
        private readonly Mock<IUserLogic> _mockUserLogic;

        private readonly GetUserProcess _objectToTest;

        public GetUserProcessTests()
        {
            _mockGetUserValidation = new Mock<IValidator<GetUserRequest>>();
            _mockValidationResultMapper = new Mock<IValidationResultMapper>();
            _mockUserLogic = new Mock<IUserLogic>();

            _objectToTest = new GetUserProcess(_mockGetUserValidation.Object, _mockValidationResultMapper.Object, _mockUserLogic.Object);
        }

        public class ValidateTests : GetUserProcessTests
        {
            private readonly GetUserRequest _request;
            private readonly ValidationResult _validationResult;
            private readonly GetUserResponse _response;


            public ValidateTests() : base()
            {
                _request = new GetUserRequest();
                _validationResult = new ValidationResult();
                _response = new GetUserResponse();

                _mockGetUserValidation
                    .Setup(x => x.ValidateAsync(It.IsAny<GetUserRequest>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(_validationResult);

                _mockValidationResultMapper
                    .Setup(x => x.MapToApiResponse<GetUserResponse>(It.IsAny<ValidationResult>()))
                    .Returns(_response);
            }

            [Fact]
            public async Task CallsValidatorValidateAsync()
            {
                var resut = await _objectToTest.Validate(_request).ConfigureAwait(false);

                _mockGetUserValidation.Verify(x => x.ValidateAsync(_request, It.IsAny<CancellationToken>()), Times.Once());
            }

            [Fact]
            public async Task CallsValidationResultMapperMapToApiResponse()
            {
                var result = await _objectToTest.Validate(_request).ConfigureAwait(false);

                _mockValidationResultMapper.Verify(x => x.MapToApiResponse<GetUserResponse>(_validationResult), Times.Once());
            }

            [Fact]
            public async Task ReturnsGetUserResponse()
            {
                var result = await _objectToTest.Validate(_request).ConfigureAwait(false);

                result.Should().Be(_response);
            }
        }

        public class ExecuteTests : GetUserProcessTests
        {
            private readonly GetUserRequest _request;
            private readonly Models.User _userModel;

            public ExecuteTests() : base()
            {
                _request = new GetUserRequest
                {
                    EmailAddress = "test@test.com"
                };

                _userModel = new Models.User
                {
                    UserId = 99,
                    EmailAddress = "test@test.com"
                };

                _mockUserLogic
                    .Setup(x => x.GetUserByEmailAddress(It.IsAny<string>()))
                    .ReturnsAsync(_userModel);
            }

            [Fact]
            public async Task CallsUserLogicGetUserByEmailAddress()
            {
                await _objectToTest.Execute(_request).ConfigureAwait(false);

                _mockUserLogic.Verify(x => x.GetUserByEmailAddress(_request.EmailAddress), Times.Once());
            }

            [Fact]
            public async Task ReturnsUserModelOnResponse()
            {
                var actual = await _objectToTest.Execute(_request).ConfigureAwait(false);


                Assert.True(actual.Success);
                actual.User.Should().Be(_userModel);
            }
        }
    }
}
