using Accountant.API.Interfaces;
using Accountant.API.Mappers;
using Accountant.API.Models.Interfaces;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Requests.SubLineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.Processes;
using Accountant.API.Processes.LineItem;
using Accountant.API.Validation.Common;
using Accountant.API.Validation.LineItem;
using Accountant.API.Validation.SubLineItem;
using FluentValidation;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectServiceCollectionHelper
    {
        public static void AddApiProjectServices(this IServiceCollection services)
        {
            services.AddTransient<IApiProcessFactory, ApiProcessFactory>();

            services.AddTransient<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>, CreateLineItemProcess>();

            services.AddTransient<IValidator<ILineItemId>, LineItemIdValidation>();
            services.AddTransient<IValidator<CreateLineItemRequest>, CreateLineItemValidation>();
            services.AddTransient<IValidator<CreateSubLineItemRequest>, CreateSubLineItemValidation>();
            

            services.AddTransient<IValidationResultMapper, ValidationResultMapper>();
        }
    }
}
