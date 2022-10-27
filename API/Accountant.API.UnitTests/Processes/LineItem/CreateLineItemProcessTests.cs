using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.Processes.LineItem;
using Accountant.Core.Interfaces;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.UnitTests.Processes.LineItem
{
    public class CreateLineItemProcessTests
    {
        private readonly CreateLineItemProcess _objectToTest;

        private readonly Mock<IValidator<CreateLineItemRequest>> _mockValidator;
        private readonly Mock<IValidationResultMapper> _mockValidationResultMapper;
        private readonly Mock<ILineItemLogic> _mockLineItemLogic;

        public CreateLineItemProcessTests()
        {
            _mockValidator = new Mock<IValidator<CreateLineItemRequest>>();
            _mockValidationResultMapper = new Mock<IValidationResultMapper>();
            _mockLineItemLogic = new Mock<ILineItemLogic>();

            _objectToTest = new CreateLineItemProcess(
                _mockValidator.Object,
                _mockValidationResultMapper.Object,
                _mockLineItemLogic.Object);
        }

        public class ValidateTests : CreateLineItemProcessTests
        {
            private readonly CreateLineItemRequest _request;

            private readonly ValidationResult _validationResult;

            private readonly CreateLineItemResponse _createLineItemResponse;

            public ValidateTests() : base()
            {
                _request = new CreateLineItemRequest();

                _validationResult = new ValidationResult();

                _createLineItemResponse = new CreateLineItemResponse();

                _mockValidator
                    .Setup(x => x.ValidateAsync(It.IsAny<CreateLineItemRequest>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(_validationResult);

                _mockValidationResultMapper
                    .Setup(x => x.MapToApiResponse<CreateLineItemResponse>(It.IsAny<ValidationResult>()))
                    .Returns(_createLineItemResponse);
            }

            [Fact]
            public async Task CallsValidatorValidateAsync()
            {
                var result = await _objectToTest.Validate(_request).ConfigureAwait(false);

                _mockValidator.Verify(x => x.ValidateAsync(_request, It.IsAny<CancellationToken>()), Times.Once());
            }

            [Fact]
            public async Task CallsValidationResultMapperMapToApiResponse()
            {
                var result = await _objectToTest.Validate(_request).ConfigureAwait(false);

                _mockValidationResultMapper.Verify(x => x.MapToApiResponse<CreateLineItemResponse>(_validationResult), Times.Once());
            }

            [Fact]
            public async Task ReturnsCreateLineItemResponse()
            {
                var result = await _objectToTest.Validate(_request).ConfigureAwait(false);

                result.Should().Be(_createLineItemResponse);
            }
        }
    }
}
