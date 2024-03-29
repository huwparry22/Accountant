﻿using Accountant.API.Interfaces;
using Accountant.API.Models;

namespace Accountant.API.Processes
{
    public class ApiProcessFactory : IApiProcessFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ApiProcessFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IApiProcess<TRequest, TResponse> GetApiProcess<TRequest, TResponse>()
            where TRequest : BaseRequest
            where TResponse : BaseResponse
        {
            var apiProcess = _serviceProvider.GetService(typeof(IApiProcess<TRequest, TResponse>)) as IApiProcess<TRequest, TResponse>;

            if (apiProcess == null)
                throw new ArgumentException($"No API Process defined for request {typeof(TRequest).Name}, response {typeof(TResponse).Name}");

            return apiProcess;
        }
    }
}
