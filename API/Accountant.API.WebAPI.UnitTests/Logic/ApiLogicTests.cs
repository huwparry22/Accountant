﻿using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.WebAPI.Interfaces;

namespace Accountant.API.WebAPI.UnitTests.Logic
{
    public class ApiLogicTests
    {
        private readonly ApiLogic _objectToTest;

        private readonly Mock<IAuthenticateUserLogic> _mockAuthenticateUserLogic;
        private readonly Mock<IApiProcessFactory> _mockApiProcessFactory;

        public ApiLogicTests()
        {
            _mockAuthenticateUserLogic = new Mock<IAuthenticateUserLogic>();
            _mockApiProcessFactory = new Mock<IApiProcessFactory>();

            _objectToTest = new ApiLogic(_mockAuthenticateUserLogic.Object, _mockApiProcessFactory.Object);
        }

        public class RunApiProcessTests : ApiLogicTests
        {
            private readonly CreateLineItemRequest _createLineItemRequest;

            private readonly CreateLineItemResponse _successResponse;
            private readonly Mock<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>> _mockCreateLineItemApiProcess;

            public RunApiProcessTests() : base()
            {
                _createLineItemRequest = new CreateLineItemRequest();

                _mockCreateLineItemApiProcess = new Mock<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>>();

                _successResponse = new CreateLineItemResponse
                {
                    Success = true
                };

                _mockCreateLineItemApiProcess
                    .Setup(x => x.Validate(It.IsAny<CreateLineItemRequest>()))
                    .ReturnsAsync(_successResponse);

                _mockCreateLineItemApiProcess
                    .Setup(x => x.Execute(It.IsAny<CreateLineItemRequest>()))
                    .ReturnsAsync(_successResponse);

                _mockApiProcessFactory
                    .Setup(x => x.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>())
                    .Returns(_mockCreateLineItemApiProcess.Object);
            }

            [Fact]
            public async Task CallsApiProcessFactoryGetApiProcess()
            {
                await _objectToTest.AuthenticateAndRunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockApiProcessFactory.Verify(x => x.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>(), Times.Once);
            }

            [Fact]
            public async Task CallsApiProcessValidate()
            {
                await _objectToTest.AuthenticateAndRunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockCreateLineItemApiProcess.Verify(x => x.Validate(_createLineItemRequest), Times.Once);
            }

            [Fact]
            public async Task CallsApiProcessExecute()
            {
                await _objectToTest.AuthenticateAndRunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockCreateLineItemApiProcess.Verify(x => x.Execute(_createLineItemRequest), Times.Once);
            }

            [Fact]
            public async Task ReturnsSuccessResponseOnExecute()
            {
                var actual = await _objectToTest.AuthenticateAndRunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockCreateLineItemApiProcess.Verify(x => x.Execute(_createLineItemRequest), Times.Once);
                actual.Should().Be(_successResponse);
            }

            private CreateLineItemResponse SetupValidateFailure()
            {
                var failureResponse = new CreateLineItemResponse
                {
                    Success = false,
                    Errors = new List<string> { "testValidateError" }
                };

                _mockCreateLineItemApiProcess
                    .Setup(x => x.Validate(It.IsAny<CreateLineItemRequest>()))
                    .ReturnsAsync(failureResponse);

                return failureResponse;
            }

            [Fact]
            public async Task ValidateFailureTests()
            {
                var exepected = SetupValidateFailure();

                var actual = await _objectToTest.AuthenticateAndRunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockApiProcessFactory.Verify(x => x.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>(), Times.Once);
                _mockCreateLineItemApiProcess.Verify(x => x.Validate(_createLineItemRequest), Times.Once);
                _mockCreateLineItemApiProcess.Verify(x => x.Execute(It.IsAny<CreateLineItemRequest>()), Times.Never);

                actual.Should().Be(exepected);
            }

            private CreateLineItemResponse SetupExecuteFaillure()
            {
                var failureResponse = new CreateLineItemResponse
                {
                    Success = false,
                    Errors = new List<string> { "testExecuteFailure" }
                };

                _mockCreateLineItemApiProcess
                    .Setup(x => x.Execute(It.IsAny<CreateLineItemRequest>()))
                    .ReturnsAsync(failureResponse);

                return failureResponse;
            }

            [Fact]
            public async Task ExecuuteFailureTests()
            {
                var expected = SetupExecuteFaillure();

                var actual = await _objectToTest.AuthenticateAndRunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockApiProcessFactory.Verify(x => x.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>(), Times.Once);
                _mockCreateLineItemApiProcess.Verify(x => x.Validate(_createLineItemRequest), Times.Once);
                _mockCreateLineItemApiProcess.Verify(x => x.Execute(It.IsAny<CreateLineItemRequest>()), Times.Once);

                actual.Should().Be(expected);
            }
        }
    }
}
