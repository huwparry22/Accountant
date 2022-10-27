using Accountant.API.Models.Requests.LineItem;
using Accountant.Core.Interfaces;
using Accountant.Core.Logic;
using Accountant.Data.Entities;
using Accountant.Data.EntityProviders;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Accountant.Core.UnitTests.Logic
{
    public class LineItemLogicTests
    {
        private readonly LineItemLogic _objectToTest;

        private readonly Mock<ILineItemMapper> _mockLineItemMapper;
        private readonly Mock<ILineItemProvider> _mockLineItemProvider;

        public LineItemLogicTests()
        {
            _mockLineItemMapper = new Mock<ILineItemMapper>();
            _mockLineItemProvider = new Mock<ILineItemProvider>();

            _objectToTest = new LineItemLogic(_mockLineItemMapper.Object, _mockLineItemProvider.Object);
        }

        public class CreateLineItemTests : LineItemLogicTests
        {
            private readonly CreateLineItemRequest _request;

            private readonly LineItem _lineItem;
            private readonly LineItem _returnLineItem;

            public CreateLineItemTests() : base()
            {
                _request = new CreateLineItemRequest
                {
                    Description = "testDescription"
                };

                _lineItem = new LineItem
                {
                    Description = "testDescription",
                    Created = DateTime.UtcNow
                };

                _returnLineItem = new LineItem
                {
                    Description = "testDescription",
                    Created = DateTime.UtcNow,
                    LineItemId = 99
                };

                _mockLineItemMapper
                    .Setup(x => x.MapToLineItem(It.IsAny<CreateLineItemRequest>()))
                    .Returns(_lineItem);

                _mockLineItemProvider
                    .Setup(x => x.SaveAsync(It.IsAny<LineItem>()))
                    .ReturnsAsync(_returnLineItem);
            }

            [Fact]
            public async Task CallsLineItemMapperMapToLineItem()
            {
                var result = await _objectToTest.CreateLineItem(_request).ConfigureAwait(false);

                _mockLineItemMapper.Verify(x => x.MapToLineItem(_request), Times.Once());
            }

            [Fact]
            public async Task CallsLineItemProviderSaveAsync()
            {
                var result = await _objectToTest.CreateLineItem(_request).ConfigureAwait(false);

                _mockLineItemProvider.Verify(x => x.SaveAsync(_lineItem), Times.Once());
            }

            [Fact]
            public async Task ReturnsLineItemId()
            {
                var result = await _objectToTest.CreateLineItem(_request).ConfigureAwait(false);

                result.Should().Be(_returnLineItem.LineItemId);
            }
        }
    }
}
