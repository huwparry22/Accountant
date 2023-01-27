using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AuthenticationHelper
    {
        public static void AddMicrosoftIdentityWebApi(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(
                configureJwtBearerOptions =>
                {
                    configuration.Bind("AzureAdB2C", configureJwtBearerOptions);

                    configureJwtBearerOptions.TokenValidationParameters.NameClaimType = "name";
                },
                configureMicrosoftIdentityOptions =>
                {
                    configuration.Bind("AzureAdB2C", configureMicrosoftIdentityOptions);
                });
        }
    }
}
