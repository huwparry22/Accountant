using Accountant.API.Interfaces;
using Accountant.API.Models;
using FluentValidation.Results;

namespace Accountant.API.Mappers
{
    public class ValidationResultMapper : IValidationResultMapper
    {
        public Response MapToApiResponse<Response>(ValidationResult validationResult) where Response : BaseResponse, new()
        {
            if (validationResult == null)
                throw new ArgumentNullException(nameof(validationResult));

            return new Response
            {
                Success = validationResult.IsValid,
                Error = validationResult.IsValid
                    ? null
                    : new Models.Common.Error
                    {
                        ErrorCode = 999,
                        ErrorMessage = validationResult.Errors.First().ErrorMessage
                    }
            };
        }
    }
}
