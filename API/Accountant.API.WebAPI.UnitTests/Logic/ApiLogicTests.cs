using Accountant.API.Models;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.WebAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Accountant.API.WebAPI.UnitTests.Logic
{
    public class ApiLogicTests
    {
        private readonly ApiLogic _objectToTest;

        private readonly Mock<IAuthenticateUserLogic> _mockAuthenticateUserLogic;
        private readonly Mock<IApiProcessLogic> _mockApiProcessLogic;

        private readonly ClaimsPrincipal _claimsPrincipal;

        public ApiLogicTests()
        {
            _mockAuthenticateUserLogic = new Mock<IAuthenticateUserLogic>();
            _mockApiProcessLogic = new Mock<IApiProcessLogic>();

            _claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, "test@test.com")
            }, "mock"));

            _objectToTest = new ApiLogic(_mockAuthenticateUserLogic.Object, _mockApiProcessLogic.Object);
            _objectToTest.ControllerContext = new Microsoft.AspNetCore.Mvc.ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = _claimsPrincipal }
            };
        }

        public class RunApiProcessTests : ApiLogicTests
        {
            private readonly CreateLineItemRequest _createLineItemRequest;

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

                _mockAuthenticateUserLogic
                    .Setup(x => x.GetAuthenticatedUser(It.IsAny<ClaimsPrincipal>()))
                    .ReturnsAsync(_authenticatedUser);

                _mockApiProcessLogic
                    .Setup(x => x.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(It.IsAny<CreateLineItemRequest>()))
                    .ReturnsAsync(_createLineItemResponse);
            }

            [Fact]
            public async Task CallsAuthenticateUserLogicGetAuthenticatedUser()
            {
                await _objectToTest.RunApiProcess<CreateLineItemRequest, CreateLineItemResponse>(_createLineItemRequest).ConfigureAwait(false);

                _mockAuthenticateUserLogic.Verify(x => x.GetAuthenticatedUser(_claimsPrincipal), Times.Once);
            }
        }
    }
}
