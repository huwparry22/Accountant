using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.Processes;
using Moq;

namespace Accountant.API.UnitTests.Processes
{
    public class ApiProcessFactoryTests
    {
        private Mock<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>> _mockCreateLineItemProcess;

        private ApiProcessFactory _objectToTest;

        private void SetupApiProcessFactoryTests(bool includeCreateLineItemService)
        {
            _mockCreateLineItemProcess = new Mock<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>>();

            var mockServiceProvider = new Mock<IServiceProvider>();

            if (includeCreateLineItemService)
            {
                mockServiceProvider
                    .Setup(x => x.GetService(typeof(IApiProcess<CreateLineItemRequest, CreateLineItemResponse>)))
                    .Returns(_mockCreateLineItemProcess.Object);
            }

            _objectToTest = new ApiProcessFactory(mockServiceProvider.Object);
        }

        [Fact]
        public void ReturnsFoundIApiProcessSuccessfully()
        {
            SetupApiProcessFactoryTests(true);

            var result = _objectToTest.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>();

            result.Should().NotBeNull();
            result.Should().BeSameAs(_mockCreateLineItemProcess.Object);
        }

        [Fact]
        public void ThrowsExceptionWhenIApiProcessNotFound()
        {
            SetupApiProcessFactoryTests(false);

            var ex = Assert.Throws<ArgumentException>(() => _objectToTest.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>());

            Assert.Equal($"No API Process defined for request {nameof(CreateLineItemRequest)}, response {nameof(CreateLineItemResponse)}", ex.Message);
        }
    }
}
