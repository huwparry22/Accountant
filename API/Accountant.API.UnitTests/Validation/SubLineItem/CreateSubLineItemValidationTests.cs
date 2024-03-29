﻿using Accountant.API.Models.Interfaces;
using Accountant.API.Models.Requests.SubLineItem;
using Accountant.API.Validation.SubLineItem;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Moq;

namespace Accountant.API.UnitTests.Validation.SubLineItem
{
    public class CreateSubLineItemValidationTests
    {
        private readonly Mock<IValidator<ILineItemId>> _mockLineItemIdValidation;

        private readonly CreateSubLineItemValidation _objectToTest;

        public CreateSubLineItemValidationTests()
        {
            _mockLineItemIdValidation = new Mock<IValidator<ILineItemId>>();

            _objectToTest = new CreateSubLineItemValidation(_mockLineItemIdValidation.Object);
        }

        private void SetupLineItemIdValidationSuccess()
        {
            _mockLineItemIdValidation
                .Setup(x => x.ValidateAsync(It.IsAny<IValidationContext>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new FluentValidation.Results.ValidationResult());
        }

        private void SetupLineItemIdValidationFailure()
        {
            _mockLineItemIdValidation
                .Setup(x => x.ValidateAsync(It.IsAny<ValidationContext<CreateSubLineItemRequest>>(), It.IsAny<CancellationToken>()))
                .Callback<IValidationContext, CancellationToken>((validationContext, cancellationToken) => ((ValidationContext<CreateSubLineItemRequest>)validationContext).AddFailure(new ValidationFailure(nameof(CreateSubLineItemRequest.LineItemId), "TestErrorMessage")));
        }

        [Fact]
        public async Task ValidSubLineItemRequest()
        {
            SetupLineItemIdValidationSuccess();

            var request = new CreateSubLineItemRequest
            {
                Amount = 99,
                Description = "testDescription",
                SubLineItemType = Models.Requests.SubLineItemType.Income
            };

            var actual = await _objectToTest.TestValidateAsync(request).ConfigureAwait(false);

            _mockLineItemIdValidation.Verify(x => x.ValidateAsync(It.IsAny<ValidationContext<CreateSubLineItemRequest>>(), It.IsAny<CancellationToken>()), Times.Once());

            actual.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task Invalid_LineItemId()
        {
            SetupLineItemIdValidationFailure();

            var request = new CreateSubLineItemRequest();

            var actual = await _objectToTest.TestValidateAsync(request).ConfigureAwait(false);

            _mockLineItemIdValidation.Verify(x => x.ValidateAsync(It.IsAny<ValidationContext<CreateSubLineItemRequest>>(), It.IsAny<CancellationToken>()), Times.Once());

            actual
                .ShouldHaveValidationErrorFor(x => x.LineItemId)
                .Only();
        }

        [Fact]
        public async Task Invalid_Amount_Empty()
        {
            SetupLineItemIdValidationSuccess();

            var request = new CreateSubLineItemRequest();

            var actual = await _objectToTest.TestValidateAsync(request).ConfigureAwait(false);

            _mockLineItemIdValidation.Verify(x => x.ValidateAsync(It.IsAny<ValidationContext<CreateSubLineItemRequest>>(), It.IsAny<CancellationToken>()), Times.Once());

            actual
                .ShouldHaveValidationErrorFor(x => x.Amount)
                .WithErrorMessage("Invalid amount - no value provided")
                .Only();
        }

        [Fact]
        public async Task Invalid_Amount_Zero()
        {
            SetupLineItemIdValidationSuccess();

            var request = new CreateSubLineItemRequest
            {
                Amount = 0
            };

            var actual = await _objectToTest.TestValidateAsync(request).ConfigureAwait(false);

            _mockLineItemIdValidation.Verify(x => x.ValidateAsync(It.IsAny<ValidationContext<CreateSubLineItemRequest>>(), It.IsAny<CancellationToken>()), Times.Once());

            actual
                .ShouldHaveValidationErrorFor(x => x.Amount)
                .WithErrorMessage("Invalid amount - invalid value")
                .Only();
        }

        [Fact]
        public async Task Invalid_Description()
        {
            SetupLineItemIdValidationSuccess();

            var request = new CreateSubLineItemRequest
            {
                Amount = 99,
                Description = string.Empty
            };

            var actual = await _objectToTest.TestValidateAsync(request).ConfigureAwait(false);

            _mockLineItemIdValidation.Verify(x => x.ValidateAsync(It.IsAny<ValidationContext<CreateSubLineItemRequest>>(), It.IsAny<CancellationToken>()), Times.Once());

            actual
                .ShouldHaveValidationErrorFor(x => x.Description)
                .WithErrorMessage("Invalid Description - no value provided")
                .Only();
        }

        [Fact]
        public async Task Invalid_SubLineItemType()
        {
            SetupLineItemIdValidationSuccess();

            var request = new CreateSubLineItemRequest
            {
                Amount = 99,
                Description = "testDescription",
                SubLineItemType = null
            };

            var actual = await _objectToTest.TestValidateAsync(request).ConfigureAwait(false);

            _mockLineItemIdValidation.Verify(x => x.ValidateAsync(It.IsAny<ValidationContext<CreateSubLineItemRequest>>(), It.IsAny<CancellationToken>()), Times.Once());

            actual
                .ShouldHaveValidationErrorFor(x => x.SubLineItemType)
                .WithErrorMessage("Invalid SubLineItemType - invalid value")
                .Only();
        }
    }
}
