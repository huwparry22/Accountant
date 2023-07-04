using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.User;
using Accountant.API.Models.Responses.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.Processes.User
{
    public class CreateUserProcess : IApiProcess<CreateUserRequest, CreateUserResponse>
    {
        private readonly IValidator<CreateUserRequest> _createUserRequestValidator;
        private readonly IValidationResultMapper _validationResultMapper;

        public CreateUserProcess(IValidator<CreateUserRequest> createUserRequestValidator, IValidationResultMapper validationResultMapper)
        {
            _createUserRequestValidator = createUserRequestValidator;
            _validationResultMapper = validationResultMapper;
        }

        public async Task<CreateUserResponse> Validate(CreateUserRequest request)
        {
            var validationResult = await _createUserRequestValidator.ValidateAsync(request).ConfigureAwait(false);

            return _validationResultMapper.MapToApiResponse<CreateUserResponse>(validationResult);
        }

        public Task<CreateUserResponse> Execute(CreateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
