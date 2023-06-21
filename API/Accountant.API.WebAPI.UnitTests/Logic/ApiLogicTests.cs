using Accountant.API.Models;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.WebAPI.Interfaces;
using System.Security.Claims;

namespace Accountant.API.WebAPI.UnitTests.Logic
{
    public class ApiLogicTests
    {
        private readonly ApiLogic _objectToTest;

        private readonly Mock<IAuthenticateUserLogic> _mockAuthenticateUserLogic;
        private readonly Mock<IApiProcessLogic> _mockApiProcessLogic;

        public ApiLogicTests()
        {
            _mockAuthenticateUserLogic = new Mock<IAuthenticateUserLogic>();
            _mockApiProcessLogic = new Mock<IApiProcessLogic>();

            _objectToTest = new ApiLogic(_mockAuthenticateUserLogic.Object, _mockApiProcessLogic.Object);
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

            
        }
    }
}
