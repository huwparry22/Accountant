using Accountant.API.Mappers;
using Accountant.API.Models.Responses.LineItem;
using FluentValidation.Results;

namespace Accountant.API.UnitTests.Mappers
{
    public class ValidationResultMapperTests
    {
        private readonly ValidationResultMapper _objectToTest;

        public ValidationResultMapperTests()
        {
            _objectToTest = new ValidationResultMapper();
        }

        public class MapToApiResponseTests : ValidationResultMapperTests
        {
            public MapToApiResponseTests() : base() { }

            [Theory]
            [ClassData(typeof(MapToApiResponseTestData))]
            public void MapToApiResponseTest(ValidationResult parameter, CreateLineItemResponse expected)
            {
                var actual = _objectToTest.MapToApiResponse<CreateLineItemResponse>(parameter);

                actual.Should().BeEquivalentTo(expected);
            }

            public class MapToApiResponseTestData : TheoryData<ValidationResult, CreateLineItemResponse>
            {
                public MapToApiResponseTestData()
                {
                    Add(
                    new ValidationResult
                    {
                        Errors = new List<ValidationFailure>()
                    },
                    new CreateLineItemResponse
                    {
                        Success = true,
                        Errors = null
                    });

                    Add(
                    new ValidationResult
                    {
                        Errors = new List<ValidationFailure> { new ValidationFailure { ErrorMessage = "testErrorMessage" } }
                    },
                    new CreateLineItemResponse
                    {
                        Success = false,
                        Errors = new List<string> { "testErrorMessage" }
                    });
                }
            }
        }
    }
}
