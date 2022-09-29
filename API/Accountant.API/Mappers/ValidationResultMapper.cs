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
                Errors = validationResult.IsValid
                    ? null
                    : validationResult.Errors.Select(e => e.ErrorMessage)
            };
        }
    }
}
