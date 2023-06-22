using Accountant.API.Interfaces;
using Accountant.API.Mappers;
using Accountant.API.Models.Interfaces;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Requests.SubLineItem;
using Accountant.API.Models.Requests.User;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.Models.Responses.SubLineItem;
using Accountant.API.Models.Responses.User;
using Accountant.API.Processes;
using Accountant.API.Processes.LineItem;
using Accountant.API.Processes.SubLineItem;
using Accountant.API.Processes.User;
using Accountant.API.Validation.Common;
using Accountant.API.Validation.LineItem;
using Accountant.API.Validation.SubLineItem;
using Accountant.API.Validation.User;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectServiceCollectionHelper
    {
        public static void AddApiProjectServices(this IServiceCollection services)
        {
            services.AddTransient<IApiProcessFactory, ApiProcessFactory>();

            services.AddTransient<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>, CreateLineItemProcess>();
            services.AddTransient<IApiProcess<CreateSubLineItemRequest, CreateSubLineItemResponse>, CreateSubLineItemProcess>();
            services.AddTransient<IApiProcess<GetUserRequest, GetUserResponse>, GetUserProcess>();
            services.AddTransient<IApiProcess<CreateUserRequest, CreateUserResponse>, CreateUserProcess>();

            services.AddTransient<IValidator<ILineItemId>, LineItemIdValidation>();
            services.AddTransient<IValidator<CreateLineItemRequest>, CreateLineItemValidation>();
            services.AddTransient<IValidator<CreateSubLineItemRequest>, CreateSubLineItemValidation>();
            services.AddTransient<IValidator<GetUserRequest>, GetUserValidation>();
            services.AddTransient<IValidator<CreateUserRequest>, CreateUserValidation>();

            services.AddTransient<IValidationResultMapper, ValidationResultMapper>();
        }
    }
}
