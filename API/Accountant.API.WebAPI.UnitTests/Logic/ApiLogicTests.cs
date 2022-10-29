﻿using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.WebAPI.UnitTests.Logic
{
    public class ApiLogicTests
    {
        private readonly ApiLogic _objectToTest;

        private readonly Mock<IApiProcessFactory> _mockApiProcessFactory;

        public ApiLogicTests()
        {
            _mockApiProcessFactory = new Mock<IApiProcessFactory>();

            _objectToTest = new ApiLogic(_mockApiProcessFactory.Object);
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
                await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockApiProcessFactory.Verify(x => x.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>(), Times.Once);
            }

            [Fact]
            public async Task CallsApiProcessValidate()
            {
                await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockCreateLineItemApiProcess.Verify(x => x.Validate(_createLineItemRequest), Times.Once);
            }

            [Fact]
            public async Task CallsApiProcessExecute()
            {
                await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockCreateLineItemApiProcess.Verify(x => x.Execute(_createLineItemRequest), Times.Once);
            }

            [Fact]
            public async Task ReturnsSuccessResponseOnExecute()
            {
                var actual = await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockCreateLineItemApiProcess.Verify(x => x.Execute(_createLineItemRequest), Times.Once);
                actual.Should().Be(_successResponse);
            }

            private CreateLineItemResponse _validateFailure;
            private void SetupValidateFailure()
            {
                _validateFailure = new CreateLineItemResponse
                {
                    Success = false,
                    Errors = new List<string> { "testValidateError" }
                };

                _mockCreateLineItemApiProcess
                    .Setup(x => x.Validate(It.IsAny<CreateLineItemRequest>()))
                    .ReturnsAsync(_validateFailure);
            }

            [Fact]
            public async Task ValidateFailureTests()
            {
                SetupValidateFailure();

                var actual = await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockApiProcessFactory.Verify(x => x.GetApiProcess<CreateLineItemRequest, CreateLineItemResponse>(), Times.Once);
                _mockCreateLineItemApiProcess.Verify(x => x.Validate(_createLineItemRequest), Times.Once);
                _mockCreateLineItemApiProcess.Verify(x => x.Execute(It.IsAny<CreateLineItemRequest>()), Times.Never);

                actual.Should().Be(_validateFailure);
            }
        }
    }
}
