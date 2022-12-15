using Accountant.API.Models.Requests.SubLineItem;
using Accountant.API.Validation.Common;
using Accountant.Core.Interfaces;
using Accountant.Data.Entities;
using FluentValidation.TestHelper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.UnitTests.Validation.Common
{
    public class LineItemIdValidationTests
    {
        private readonly Mock<ILineItemLogic> _mockLineItemLogic;

        private readonly LineItemIdValidation _objectToTest;

        public LineItemIdValidationTests()
        {
            _mockLineItemLogic = new Mock<ILineItemLogic>();

            
            _objectToTest = new LineItemIdValidation(_mockLineItemLogic.Object);
        }

        [Fact]
        public async Task ValidLineItemId()
        {
            var lineItem = new Data.Entities.LineItem
            {
                LineItemId = 99
            };

            _mockLineItemLogic
                .Setup(x => x.GetLineItemByLineItemId(It.IsAny<int>()))
                .ReturnsAsync(lineItem);

            var request = new CreateSubLineItemRequest
            {
                LineItemId = lineItem.LineItemId
            };

            var actual = await _objectToTest.TestValidateAsync(request).ConfigureAwait(false);

            _mockLineItemLogic.Verify(x => x.GetLineItemByLineItemId(request.LineItemId.Value), Times.Once());
            actual.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task Invalid_NullLineItemId()
        {
            var request = new CreateSubLineItemRequest();

            var actual = await _objectToTest.TestValidateAsync(request).ConfigureAwait(false);

            actual
                .ShouldHaveValidationErrorFor(x => x.LineItemId)
                .WithErrorMessage("Invalid LineItemId - no value provided");
        }

        [Fact]
        public async Task Invalid_LineItemIdNotFound()
        {
            _mockLineItemLogic
                .Setup(x => x.GetLineItemByLineItemId(It.IsAny<int>()))
                .ReturnsAsync((Data.Entities.LineItem)null);

            var request = new CreateSubLineItemRequest
            {
                LineItemId = 99
            };

            var actual = await _objectToTest.TestValidateAsync(request).ConfigureAwait(false);

            actual
                .ShouldHaveValidationErrorFor(x => x.LineItemId)
                .WithErrorMessage("Invalid LineItemId - not found");
        }
    }
}
