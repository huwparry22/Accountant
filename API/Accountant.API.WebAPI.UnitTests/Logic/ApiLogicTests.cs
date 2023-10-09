using Accountant.API.Models;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.WebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Accountant.API.WebAPI.UnitTests.Logic
{
    public class ApiLogicTests
    {
        private readonly ApiLogic _objectToTest;

        private readonly Mock<IApiLogicAggregator> _mockApiLogicAggregator;
        private readonly Mock<IAuthenticateUserLogic> _mockAuthenticateUserLogic;
        private readonly Mock<IApiProcessLogic> _mockApiProcessLogic;

        private readonly ClaimsPrincipal _claimsPrincipal;

        public ApiLogicTests()
        {
            _mockApiLogicAggregator = new Mock<IApiLogicAggregator>();
            _mockAuthenticateUserLogic = new Mock<IAuthenticateUserLogic>();
            _mockApiProcessLogic = new Mock<IApiProcessLogic>();

            _mockApiLogicAggregator
                .Setup(x => x.AuthenticateUserLogic)
                .Returns(_mockAuthenticateUserLogic.Object);

            _mockApiLogicAggregator
                .Setup(x => x.ApiProcessLogic)
                .Returns(_mockApiProcessLogic.Object);

            _objectToTest = new ApiLogic(_mockApiLogicAggregator.Object);
            _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, "test@test.com")
            }, "mock"));

            _objectToTest.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = _claimsPrincipal }
            };
        }

        public class RunApiProcessTests : ApiLogicTests
        {
            private readonly CreateLineItemRequest _createLineItemRequest;

            private BaseResponse _baseResponse;
            private readonly User? _authenticatedUser;
            private readonly CreateLineItemResponse _createLineItemResponse;

            public RunApiProcessTests() : base()
            {
                _createLineItemRequest = new CreateLineItemRequest();

                _authenticatedUser = new User
                {
                    EmailAddress = "test@test.com",
                    UserId = 99
                };

                _createLineItemResponse = new CreateLineItemResponse
                {
                    Success = true,
                    LineItemId = 99
                };

                _mockApiProcessLogic
                    .Setup(x => x.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(It.IsAny<CreateLineItemRequest>()))
                    .ReturnsAsync(_createLineItemResponse);
            }

            private void SetUpBaseResponse(bool isSuccess)
            {
                _baseResponse = new BaseResponse
                {
                    Success = isSuccess
                };

                _mockAuthenticateUserLogic
                    .Setup(x => x.GetAuthenticatedUser(It.IsAny<ClaimsPrincipal>()))
                    .ReturnsAsync((_baseResponse, _authenticatedUser));
            }

            [Fact]
            public async Task CallsAuthenticateUserLogicGetAuthenticatedUser()
            {
                SetUpBaseResponse(true);

                await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockAuthenticateUserLogic.Verify(x => x.GetAuthenticatedUser(_claimsPrincipal), Times.Once);

                _createLineItemRequest.AuthenticatedUser.Should().Be(_authenticatedUser);
            }

            [Fact]
            public async Task CallsApiProcessLogicRunApiProcessOnSuccessfulAuthenticatedUser()
            {
                SetUpBaseResponse(true);

                await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockApiProcessLogic.Verify(x => x.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest), Times.Once);
            }

            [Fact]
            public async Task NotCallApiProcessLogicRunApiProcessOnUnsuccessfulAuthenticatedUser()
            {
                SetUpBaseResponse(false);

                var actual = await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                actual.Result.Should().BeOfType<UnauthorizedObjectResult>().Which.StatusCode.Should().Be((int)HttpStatusCode.Unauthorized);
                _mockApiProcessLogic.Verify(x => x.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest), Times.Never);
            }
        }
    }
}
