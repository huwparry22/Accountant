namespace Accountant.API.WebAPI.Middleware
{
    public class ApiKeyAuthenticationMiddleware
    {
        private const string API_KEY_HEADER_NAME = "X-API-Key";

        private readonly RequestDelegate _next;

        public ApiKeyAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        {
            if (!context.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var headerApiKeyValue))
            {
                context.Response.StatusCode = 401;

                return;
            }

            var acceptedApiKey = configuration.GetValue<string>("AllowedApiKey");

            if (!headerApiKeyValue.Equals(acceptedApiKey))
            {
                context.Response.StatusCode = 401;

                return;
            }

            await _next(context);
        }
    }
}
