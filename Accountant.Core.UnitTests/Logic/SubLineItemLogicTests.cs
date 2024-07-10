using Accountant.API.Models.Requests.SubLineItem;
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
    public class SubLineItemLogicTests
    {
        private readonly Mock<ISubLineItemMapper> _mockSubLineItemMapper;
        private readonly Mock<ISubLineItemProvider> _mockSubLineItemProvider;

        private readonly CreateSubLineItemRequest _createSubLineItemRequest;
        private readonly SubLineItem _subLineItem;
        private readonly int _subLineItemId;

        private readonly SubLineItemLogic _objectToTest;

        public SubLineItemLogicTests()
        {
            _createSubLineItemRequest = new CreateSubLineItemRequest();
            _subLineItem = new SubLineItem();
            _subLineItemId = 99;

            _mockSubLineItemMapper = new Mock<ISubLineItemMapper>();
            _mockSubLineItemMapper
                .Setup(x => x.GetSubLineItem(It.IsAny<CreateSubLineItemRequest>()))
                .Returns(_subLineItem);

            _mockSubLineItemProvider = new Mock<ISubLineItemProvider>();
            _mockSubLineItemProvider
                .Setup(x => x.SaveAsync(It.IsAny<SubLineItem>()))
                .Callback<SubLineItem>((subLineItem) => subLineItem.SubLineItemId = _subLineItemId);

            _objectToTest = new SubLineItemLogic(_mockSubLineItemMapper.Object, _mockSubLineItemProvider.Object);
        }

        [Fact]
        public async Task CallsSubLineItemMapperGetSubLineItem()
        {
            await _objectToTest.CreateSubLineItem(_createSubLineItemRequest).ConfigureAwait(false);

            _mockSubLineItemMapper.Verify(x => x.GetSubLineItem(_createSubLineItemRequest), Times.Once());
        }

        [Fact]
        public async Task CallsSubLineItemProviderSaveAsync()
        {
            await _objectToTest.CreateSubLineItem(_createSubLineItemRequest).ConfigureAwait(false);

            _mockSubLineItemProvider.Verify(x => x.SaveAsync(_subLineItem), Times.Once());
        }

        [Fact]
        public async Task ReturnsSubLineItemId()
        {
            var actual = await _objectToTest.CreateSubLineItem(_createSubLineItemRequest).ConfigureAwait(false);

            actual.Should().Be(_subLineItemId);
        }
    }
}
