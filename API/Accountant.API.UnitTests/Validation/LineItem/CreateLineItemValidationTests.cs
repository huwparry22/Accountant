using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Validation.LineItem;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void IsValid()
        {
            //Arrange
            var request = new CreateLineItemRequest
            {
                Description = "testing"
            };

            //Act
            var result = _objectToTest.TestValidate(request);

            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
