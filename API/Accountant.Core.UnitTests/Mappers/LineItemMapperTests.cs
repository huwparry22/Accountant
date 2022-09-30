using Accountant.API.Models.Requests.LineItem;
using Accountant.Core.Mappers;
using Accountant.Data.Entities;
using FluentAssertions;
using FluentAssertions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Accountant.Core.UnitTests.Mappers
{
    public class LineItemMapperTests
    {
        private readonly LineItemMapper _objectToTest;

        public LineItemMapperTests()
        {
            _objectToTest = new LineItemMapper();
        }

        [Theory]
        [ClassData(typeof(LineItemMapperMapToLineItemTestData))]
        public void MapToLineItemTests(CreateLineItemRequest? createLineItemRequest, LineItem? expected)
        {
            if (createLineItemRequest == null)
            {
                _objectToTest.Invoking(o => o.MapToLineItem(createLineItemRequest))
                    .Should()
                    .ThrowExactly<ArgumentNullException>();
            }
            else
            {
                var actual = _objectToTest.MapToLineItem(createLineItemRequest);

                actual.Should().BeEquivalentTo(expected, options =>
                    options.Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation, 1.Minutes())).WhenTypeIs<DateTime>());
            }
        }

        public class LineItemMapperMapToLineItemTestData : TheoryData<CreateLineItemRequest?, LineItem?>
        {
            public LineItemMapperMapToLineItemTestData()
            {
                Add(null, null);

                Add(
                    new CreateLineItemRequest
                    {
                        Description = "unitTestData",
                    },
                    new LineItem
                    {
                        Description = "unitTestData",
                        Created = DateTime.UtcNow
                    });
            }
        }
    }
}
