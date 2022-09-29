using Accountant.API.Models;
using FluentValidation.Results;

namespace Accountant.API.Interfaces
{
    public interface IValidationResultMapper
    {
        Response MapToApiResponse<Response>(ValidationResult validationResult)
            where Response : BaseResponse, new();
    }
}
