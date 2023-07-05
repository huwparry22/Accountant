using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.User;
using Accountant.API.Models.Responses.User;
using Accountant.Core.Interfaces;
using FluentValidation;

namespace Accountant.API.Processes.User
{
    public class CreateUserProcess : IApiProcess<CreateUserRequest, CreateUserResponse>
    {
        private readonly IValidator<CreateUserRequest> _createUserRequestValidator;
        private readonly IValidationResultMapper _validationResultMapper;
        private readonly IUserLogic _userLogic;

        public CreateUserProcess(IValidator<CreateUserRequest> createUserRequestValidator, IValidationResultMapper validationResultMapper, IUserLogic userLogic)
        {
            _createUserRequestValidator = createUserRequestValidator;
            _validationResultMapper = validationResultMapper;
            _userLogic = userLogic;
        }

        public async Task<CreateUserResponse> Validate(CreateUserRequest request)
        {
            var validationResult = await _createUserRequestValidator.ValidateAsync(request).ConfigureAwait(false);

            return _validationResultMapper.MapToApiResponse<CreateUserResponse>(validationResult);
        }

        public async Task<CreateUserResponse> Execute(CreateUserRequest request)
        {
            var userModel = await _userLogic.SaveUser(request).ConfigureAwait(false);

            return new CreateUserResponse
            {
                Success = true,
                User = userModel
            };
        }
    }
}
