using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.WebAPI.UnitTests.Logic
{
    public class ApiProcessLogicTests
    {
        private readonly Mock<IApiProcessFactory> _mockApiProcessFactory;

        private readonly ApiProcessLogic _objectToTest;

        public ApiProcessLogicTests()
        {
            _mockApiProcessFactory = new Mock<IApiProcessFactory>();

            _objectToTest = new ApiProcessLogic(_mockApiProcessFactory.Object);
        }

        public class RunApiProcessTests : ApiProcessLogicTests
        {
            private readonly CreateLineItemRequest _createLineItemRequest;

            private Mock<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>> _mockCreateLineItemApiProcess;

            public RunApiProcessTests() : base()
            {
                _createLineItemRequest = new CreateLineItemRequest
                {
                    Description = "testDescription"
                };

                _mockCreateLineItemApiProcess = new Mock<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>>();
                _mockApiProcessFactory
                    .Setup(x => x.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>())
                    .Returns(_mockCreateLineItemApiProcess.Object);
            }

            private CreateLineItemResponse SetUpValidateResponse(bool success)
            {
                var validateResponse = new CreateLineItemResponse
                {
                    Success = success,
                    Errors = success ? null : new List<string> { "testValidateError" }
                };

                _mockCreateLineItemApiProcess
                    .Setup(x => x.Validate(It.IsAny<CreateLineItemRequest>()))
                    .ReturnsAsync(validateResponse);

                return validateResponse;
            }

            private CreateLineItemResponse SetUpExecuteResponse(bool success)
            {
                var executeResponse = new CreateLineItemResponse
                {
                    Success = success,
                    Errors = success ? null : new List<string> { "testExecuteError" },
                    LineItemId = success ? 99 : default
                };

                _mockCreateLineItemApiProcess
                    .Setup(x => x.Execute(It.IsAny<CreateLineItemRequest>()))
                    .ReturnsAsync(executeResponse);

                return executeResponse;
            }

            [Fact]
            public async Task CallsApiProcessFactoryGetApiProcess()
            {
                SetUpValidateResponse(true);
                SetUpExecuteResponse(true);

                await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockApiProcessFactory.Verify(x => x.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>(), Times.Once);
            }

            [Fact]
            public async Task CallsApiProcessValidate()
            {
                SetUpValidateResponse(true);
                SetUpExecuteResponse(true);

                await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockCreateLineItemApiProcess.Verify(x => x.Validate(_createLineItemRequest), Times.Once);
            }

            [Fact]
            public async Task CallsApiProcessExecute()
            {
                SetUpValidateResponse(true);
                SetUpExecuteResponse(true);

                await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockCreateLineItemApiProcess.Verify(x => x.Execute(_createLineItemRequest), Times.Once);
            }

            [Fact]
            public async Task ReturnsSuccessResponseOnExecute()
            {
                SetUpValidateResponse(true);
                var expected = SetUpExecuteResponse(true);

                var actual = await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                actual.Should().Be(expected);
            }

            [Fact]
            public async Task ValidateFailureTests()
            {
                var expected = SetUpValidateResponse(false);

                var actual = await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockApiProcessFactory.Verify(x => x.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>(), Times.Once);
                _mockCreateLineItemApiProcess.Verify(x => x.Validate(_createLineItemRequest), Times.Once);
                _mockCreateLineItemApiProcess.Verify(x => x.Execute(It.IsAny<CreateLineItemRequest>()), Times.Never);

                actual.Should().Be(expected);
            }
        }
    }
}
