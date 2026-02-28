namespace Kikoff.BuildingBlocks.Multitenancy.Providers;

internal sealed class ClaimsBasedTenantContextConfig
{
    public string ClaimType { get; set; } = "tenant_id";
}
