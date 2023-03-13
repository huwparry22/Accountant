using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.User;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.Models.Responses.User;
using Accountant.Core.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.Processes.User
{
    public class GetUserProcess : IApiProcess<GetUserRequest, GetUserResponse>
    {
        private readonly IValidator<GetUserRequest> _validator;
        private readonly IValidationResultMapper _validationResultMapper;
        private readonly IUserLogic _userLogic;

        public GetUserProcess(IValidator<GetUserRequest> validator, IValidationResultMapper validationResultMapper, IUserLogic userLogic)
        {
            _validator = validator;
            _validationResultMapper = validationResultMapper;
            _userLogic = userLogic;
        }

        public async Task<GetUserResponse> Validate(GetUserRequest request)
        {
            var validationResult = await _validator.ValidateAsync(request).ConfigureAwait(false);

            return _validationResultMapper.MapToApiResponse<GetUserResponse>(validationResult);
        }

        public Task<GetUserResponse> Execute(GetUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
