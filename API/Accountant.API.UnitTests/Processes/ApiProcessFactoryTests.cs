using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.Processes;
using Accountant.API.Processes.LineItem;
using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Accountant.API.UnitTests.Processes
{
    public class ApiProcessFactoryTests
    {
        private readonly Mock<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>> _mockCreateLineItemProcess;

        private readonly ApiProcessFactory _objectToTest;

        public ApiProcessFactoryTests()
        {
            _mockCreateLineItemProcess = new Mock<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>>();

            var mockServiceProvider = new Mock<IServiceProvider>();
            mockServiceProvider
                .Setup(x => x.GetService(typeof(IApiProcess<CreateLineItemRequest, CreateLineItemResponse>)))
                .Returns(_mockCreateLineItemProcess.Object);

            _objectToTest = new ApiProcessFactory(mockServiceProvider.Object);
        }

        [Fact]
        public void ReturnsFoundIApiProcessSuccessfully()
        {
            var result = _objectToTest.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>();

            result.Should().NotBeNull();
            result.Should().BeSameAs(_mockCreateLineItemProcess.Object);
        }
    }
}
