using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.SubLineItem;
using Accountant.API.Models.Responses.SubLineItem;
using Accountant.API.Processes.SubLineItem;
using Accountant.Core.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace Accountant.API.UnitTests.Processes.SubLineItem
{
    public class CreateSubLineItemProcessTests
    {
        private readonly Mock<IValidator<CreateSubLineItemRequest>> _mockValidator;
        private readonly Mock<IValidationResultMapper> _mockValidationResultMapper;
        private readonly Mock<ISubLineItemLogic> _mockSubLineItemLogic;

        private readonly CreateSubLineItemProcess _objectToTest;

        public CreateSubLineItemProcessTests()
        {
            _mockValidator = new Mock<IValidator<CreateSubLineItemRequest>>();
            _mockValidationResultMapper = new Mock<IValidationResultMapper>();
            _mockSubLineItemLogic = new Mock<ISubLineItemLogic>();

            _objectToTest = new CreateSubLineItemProcess(_mockValidator.Object, _mockValidationResultMapper.Object, _mockSubLineItemLogic.Object);
        }

        public class ValidateTests : CreateSubLineItemProcessTests
        {
            private readonly CreateSubLineItemRequest _request;

            private readonly ValidationResult _validationResult;

            private readonly CreateSubLineItemResponse _createSubLineItemResponse;

            public ValidateTests() : base()
            {
                _request = new CreateSubLineItemRequest();

                _validationResult = new ValidationResult();

                _createSubLineItemResponse = new CreateSubLineItemResponse();

                _mockValidator
                    .Setup(x => x.ValidateAsync(It.IsAny<CreateSubLineItemRequest>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(_validationResult);

                _mockValidationResultMapper
                    .Setup(x => x.MapToApiResponse<CreateSubLineItemResponse>(It.IsAny<ValidationResult>()))
                    .Returns(_createSubLineItemResponse);
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

                _mockValidationResultMapper.Verify(x => x.MapToApiResponse<CreateSubLineItemResponse>(_validationResult),
                    Times.Once());
            }

            [Fact]
            public async Task ReturnsCreateSubLineItemResponse()
            {
                var result = await _objectToTest.Validate(_request).ConfigureAwait(false);

                result.Should().Be(_createSubLineItemResponse);
            }
        }

        public class ExecuteTests : CreateSubLineItemProcessTests
        {
            private readonly CreateSubLineItemRequest _request;

            private readonly CreateSubLineItemResponse _createSubLineItemResponse;

            private readonly int _subLineItemId = 99;

            public ExecuteTests() : base()
            {
                _request = new CreateSubLineItemRequest();

                _createSubLineItemResponse = new CreateSubLineItemResponse
                {
                    Success = true,
                    SubLineItemId = _subLineItemId
                };

                _mockSubLineItemLogic
                    .Setup(x => x.CreateSubLineItem(It.IsAny<CreateSubLineItemRequest>()))
                    .ReturnsAsync(_subLineItemId);
            }

            [Fact]
            public async Task CallsSubLineItemLogicCreateSubLineItem()
            {
                var result = await _objectToTest.Execute(_request).ConfigureAwait(false);

                _mockSubLineItemLogic.Verify(x => x.CreateSubLineItem(_request), Times.Once);
            }

            [Fact]
            public async Task ReturnsCorrectCreateSubLineItemResponse()
            {
                var result = await _objectToTest.Execute(_request).ConfigureAwait(false);

                result.Should().BeEquivalentTo(_createSubLineItemResponse);
            }
        }
    }
}
