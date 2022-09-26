using Accountant.API.Interfaces;
using Accountant.API.Models.Requests.LineItem;
using Accountant.API.Models.Responses.LineItem;
using Accountant.API.Processes.LineItem;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accountant.API.Bootstrapper
{
    public static class ProjectServiceCollectionHelper
    {
        public static void AddApiProjectServices(this IServiceCollection services)
        {
            services.AddTransient<IApiProcess<CreateLineItemRequest, CreateLineItemResponse>, CreateLineItemProcess>();
        }
    }
}
