using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Kikoff.BuildingBlocks.Http.Cors;

public static class WebApplicationBuilderExtensions
{
    private const string CorsConfigSectionName = "Cors";

    extension(WebApplicationBuilder applicationBuilder)
    {
        public WebApplicationBuilder AddKikoffCors()
        {
            CorsOptionsConfig config = applicationBuilder.Configuration
                .GetSection(CorsConfigSectionName)
                .Get<CorsOptionsConfig>() ?? new();

            if (config.AllowedOrigins.Length == 0)
            {
                Log.Warning("No allowed origins configured for CORS. Skipping CORS configuration.");
                return applicationBuilder;
            }

            applicationBuilder.Services.AddCors(options =>
            {
                options.AddPolicy(CorsOptionsConfig.PolicyName, policy =>
                {
                    policy
                        .WithOrigins(config.AllowedOrigins)
                        .WithMethods(config.AllowedMethods)
                        .WithHeaders(config.AllowedHeaders);

                    if (config.AllowCredentials)
                    {
                        policy.AllowCredentials();
                    }
                });
            });

            return applicationBuilder;
        }
    }
}
