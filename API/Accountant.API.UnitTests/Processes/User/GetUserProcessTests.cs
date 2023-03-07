using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.User;
using Accountant.API.Models.Responses.User;
using Accountant.API.Processes.User;
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

        private readonly GetUserProcess _objectToTest;

        public GetUserProcessTests()
        {
            _mockGetUserValidation = new Mock<IValidator<GetUserRequest>>();
            _mockValidationResultMapper = new Mock<IValidationResultMapper>();

            _objectToTest = new GetUserProcess(_mockGetUserValidation.Object, _mockValidationResultMapper.Object);
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
        }
    }
}
