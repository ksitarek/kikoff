using System.Security.Claims;
using Kikoff.BuildingBlocks.Multitenancy.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Kikoff.BuildingBlocks.Multitenancy.Providers;

public sealed class ClaimsBasedTenantContextProvider : ITenantContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private string _claimType;

    private HttpContext? HttpContent => _httpContextAccessor.HttpContext;
    private ClaimsPrincipal? User => HttpContent?.User;
    private IEnumerable<Claim> Claims => User?.Claims ?? [];
    private Claim? TenantClaim => Claims.FirstOrDefault(c => c.Type == _claimType);

    internal ClaimsBasedTenantContextProvider(
        IOptionsMonitor<ClaimsBasedTenantContextConfig> options,
        IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;

        _claimType = options.CurrentValue.ClaimType;
        options.OnChange(x => _claimType = x.ClaimType);
    }

    public Guid? GetTenantId()
    {
        return TenantClaim is null ? null : Guid.Parse(TenantClaim.Value);
    }

    public Guid GetRequiredTenantId()
    {
        return GetTenantId() ?? throw new InvalidOperationException("Tenant ID is required but was not provided.");
    }
}