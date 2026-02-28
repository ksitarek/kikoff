using Kikoff.BuildingBlocks.Multitenancy.Abstractions;
using Kikoff.BuildingBlocks.Multitenancy.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kikoff.BuildingBlocks.Multitenancy.Extensions;

internal static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        internal IServiceCollection AddKikoffTenantContext(IConfigurationSection section)
        {
            services.Configure<ClaimsBasedTenantContextConfig>(section);

            services.AddHttpContextAccessor();
            services.AddOptions();

            services.AddScoped<ITenantContext>(sp =>
            {
                return TryGetClaimsBasedTenantContextProvider(sp)
                       ?? sp.GetRequiredService<ScopedTenantContextProvider>();
            });
            return services;
        }

        private static ITenantContext? TryGetClaimsBasedTenantContextProvider(IServiceProvider sp)
        {
            IHttpContextAccessor? httpContextAccessor = sp.GetService<IHttpContextAccessor>();

            if (httpContextAccessor is null)
            {
                return null;
            }

            IOptionsMonitor<ClaimsBasedTenantContextConfig>? options = sp.GetClaimsBasedTenantContextConfig();

            if (options is null)
            {
                return null;
            }

            return new ClaimsBasedTenantContextProvider(options, httpContextAccessor);
        }
    }
}
