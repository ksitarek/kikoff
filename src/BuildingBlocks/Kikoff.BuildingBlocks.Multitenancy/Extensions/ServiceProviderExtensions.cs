using Kikoff.BuildingBlocks.Multitenancy.Abstractions;
using Kikoff.BuildingBlocks.Multitenancy.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kikoff.BuildingBlocks.Multitenancy.Extensions;

internal static class ServiceProviderExtensions
{
    extension(IServiceProvider serviceProvider)
    {
        public IOptionsMonitor<ClaimsBasedTenantContextConfig>? GetClaimsBasedTenantContextConfig()
        {
            return serviceProvider.GetService<IOptionsMonitor<ClaimsBasedTenantContextConfig>>();
        }
    }
}