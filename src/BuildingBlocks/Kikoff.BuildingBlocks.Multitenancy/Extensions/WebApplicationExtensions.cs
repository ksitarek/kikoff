using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Kikoff.BuildingBlocks.Multitenancy.Extensions;

public static class WebApplicationExtensions
{
    private const string TenantContextConfigSectionName = "TenantContext";

    extension(WebApplicationBuilder builder)
    {
        public WebApplicationBuilder AddTenantContext()
        {
            IConfigurationSection section = builder.Configuration.GetSection(TenantContextConfigSectionName);

            builder.Services.AddKikoffTenantContext(section);

            return builder;
        }
    }
}