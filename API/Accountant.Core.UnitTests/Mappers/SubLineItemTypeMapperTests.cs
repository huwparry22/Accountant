using Accountant.Core.Mappers;
using Accountant.Data.Entities.Enums;
using FluentAssertions;
using System;
using Xunit;

namespace Accountant.Core.UnitTests.Mappers
{
    public class SubLineItemTypeMapperTests
    {
        private readonly SubLineItemTypeMapper _objectToTest;

        public SubLineItemTypeMapperTests()
        {
            _objectToTest = new SubLineItemTypeMapper();
        }

        [Theory]
        [ClassData(typeof(SubLineItemTypeMapperGetEntitySubLineItemTypeTestData))]
        public void GetEntitySubLineItemType(SubLineItemType? expected, API.Models.Requests.SubLineItemType? parameter)
        {
            if (!parameter.HasValue)
            {
                _objectToTest
                    .Invoking(o => o.GetEntitySubLineItemType(parameter))
                    .Should()
                    .Throw<ArgumentNullException>()
                    .WithMessage("Value cannot be null. (Parameter 'subLineItemTypeModel')");
            }
            else
            {
                var actual = _objectToTest.GetEntitySubLineItemType(parameter.Value);

                expected.Should().Be(actual);
            }
        }

        public class SubLineItemTypeMapperGetEntitySubLineItemTypeTestData : TheoryData<SubLineItemType?, API.Models.Requests.SubLineItemType?>
        {
            public SubLineItemTypeMapperGetEntitySubLineItemTypeTestData()
            {
                Add(null, null);
                Add(SubLineItemType.Income, API.Models.Requests.SubLineItemType.Income);
                Add(SubLineItemType.Expenditure, API.Models.Requests.SubLineItemType.Expenditure);
            }
        }
    }
}
