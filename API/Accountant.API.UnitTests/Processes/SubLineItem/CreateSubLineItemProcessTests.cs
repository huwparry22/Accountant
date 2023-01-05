using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.SubLineItem;
using Accountant.Core.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Accountant.API.Processes.SubLineItem;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.Models.Responses.SubLineItem;
using FluentValidation.Results;

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
            public async Task ReturnsCreateLineItemResponse()
            {
                var result = await _objectToTest.Validate(_request).ConfigureAwait(false);

                result.Should().Be(_createSubLineItemResponse);
            }
        }
    }
}
