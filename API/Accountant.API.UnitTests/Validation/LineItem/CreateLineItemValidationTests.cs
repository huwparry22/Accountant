﻿using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Validation.LineItem;
using FluentValidation.TestHelper;

namespace Accountant.API.UnitTests.Validation.LineItem
{
    public class CreateLineItemValidationTests
    {
        private readonly CreateLineItemValidation _objectToTest;

        public CreateLineItemValidationTests()
        {
            _objectToTest = new CreateLineItemValidation();
        }

        [Fact]
        public void IsValid_Description()
        {
            var request = new CreateLineItemRequest
            {
                Description = "testing"
            };

            var result = _objectToTest.TestValidate(request);

            result.ShouldNotHaveValidationErrorFor(req => req.Description);
        }

        [Fact]
        public void IsNotValid_Description_EmptyString()
        {
            var request = new CreateLineItemRequest
            {
                Description = ""
            };

            var result = _objectToTest.TestValidate(request);

            AssertInvalidDescriptionError(result);
        }

        [Fact]
        public void IsNotValid_Description_WhiteSpace()
        {
            var request = new CreateLineItemRequest
            {
                Description = " "
            };

            var result = _objectToTest.TestValidate(request);

            AssertInvalidDescriptionError(result);
        }

        [Fact]
        public void IsNotValid_Description_Null()
        {
            var request = new CreateLineItemRequest();

            var result = _objectToTest.TestValidate(request);

            AssertInvalidDescriptionError(result);
        }

        private static void AssertInvalidDescriptionError(TestValidationResult<CreateLineItemRequest> result)
        {
            result
                .ShouldHaveValidationErrorFor(req => req.Description)
                .WithErrorMessage("Invalid description");
        }
    }
}
