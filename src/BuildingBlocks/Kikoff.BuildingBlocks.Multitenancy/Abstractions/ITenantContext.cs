namespace Kikoff.BuildingBlocks.Multitenancy.Abstractions;

public interface ITenantContext
{
    Guid? GetTenantId();
    Guid GetRequiredTenantId();
}
