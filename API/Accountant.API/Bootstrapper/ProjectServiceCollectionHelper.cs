using Accountant.API.Interfaces;
using Accountant.API.Mappers;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.Processes.LineItem;
using Accountant.API.Validation.LineItem;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProjectServiceCollectionHelper
    {
        public static void AddApiProjectServices(this IServiceCollection services)
        {
            services.AddTransient<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>, CreateLineItemProcess>();

            services.AddTransient<IValidator<CreateLineItemRequest>, CreateLineItemValidation>();

            services.AddTransient<IValidationResultMapper, ValidationResultMapper>();
        }
    }
}
