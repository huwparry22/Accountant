using Accountant.API.Models.Requests.SubLineItem;
using Accountant.Core.Interfaces;
using Accountant.Core.Mappers;
using Accountant.Data.Entities;
using Accountant.Data.Entities.Enums;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Accountant.Core.UnitTests.Mappers
{
    public class SubLineItemMapperTests
    {
        private readonly Mock<ISubLineItemTypeMapper> _mockSubLineItemTypeMapper;

        private const SubLineItemType TestSubLineItemTypeEntity = SubLineItemType.Income;

        private readonly SubLineItemMapper _objectToTest;

        public SubLineItemMapperTests()
        {
            _mockSubLineItemTypeMapper = new Mock<ISubLineItemTypeMapper>();

            _mockSubLineItemTypeMapper
                .Setup(x => x.GetEntitySubLineItemType(It.IsAny<Accountant.API.Models.Requests.SubLineItemType>()))
                .Returns(TestSubLineItemTypeEntity);

            _objectToTest = new SubLineItemMapper(_mockSubLineItemTypeMapper.Object);
        }

        public class GetSubLineItemTests : SubLineItemMapperTests
        {
            public GetSubLineItemTests() : base()
            {

            }

            [Fact]
            public void ArgumentNullExceptionWhenParameterIsNull()
            {
                _objectToTest
                    .Invoking(o => o.GetSubLineItem(null))
                    .Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage("Value cannot be null. (Parameter 'subLineItemRequest')");
            }

            [Fact]
            public void ArgumentExceptionWhenLineItemIdIsNull()
            {
                var request = new CreateSubLineItemRequest
                {
                    LineItemId = null
                };

                _objectToTest
                    .Invoking(o => o.GetSubLineItem(request))
                    .Should()
                    .Throw<ArgumentException>()
                    .WithMessage("LineItemId property cannot be null (Parameter 'subLineItemRequest')");
            }

            [Fact]
            public void ArgumentExceptionWhenAmountIsNull()
            {
                var request = new CreateSubLineItemRequest
                {
                    LineItemId = 99,
                    Amount = null
                };

                _objectToTest
                    .Invoking(o => o.GetSubLineItem(request))
                    .Should()
                    .Throw<ArgumentException>()
                    .WithMessage("Amount property cannot be null (Parameter 'subLineItemRequest')");
            }

            //[Theory]
            //[ClassData(typeof(GetSubLineItemTestData))]
            //public void GetSubLineItemTheoryDataTests(CreateSubLineItemRequest? parameter, SubLineItem? expected)
            //{
            //}
        }

        public class GetSubLineItemTestData : TheoryData<CreateSubLineItemRequest?, SubLineItem?>
        {
            public GetSubLineItemTestData()
            {
                Add(null, null);

                //Add(new CreateSubLineItemRequest
                //    {
                //        LineItemId = null
                //    },
                //    null);

                //Add(new CreateSubLineItemRequest
                //    {
                //        Amount = null
                //    },
                //    null);
            }
        }
    }
}
