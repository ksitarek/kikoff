using Kikoff.BuildingBlocks.Multitenancy.Abstractions;

namespace Kikoff.BuildingBlocks.Multitenancy.Providers;

public sealed class ScopedTenantContextProvider : ITenantContext
{
    private readonly Guid? _tenantId;

    public ScopedTenantContextProvider(Guid? tenantId)
    {
        _tenantId = tenantId;
    }

    public Guid? GetTenantId()
    {
        return _tenantId;
    }

    public Guid GetRequiredTenantId()
    {
        return GetTenantId() ?? throw new InvalidOperationException("Tenant ID is required but was not provided.");
    }
}