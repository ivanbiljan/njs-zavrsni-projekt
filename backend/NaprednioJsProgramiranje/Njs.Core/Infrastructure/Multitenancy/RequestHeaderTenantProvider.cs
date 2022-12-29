using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Njs.Core.Shared.Multitenancy;

public sealed class RequestHeaderTenantProvider : ITenantProvider
{
    public TenantProviderResult? GetTenant(HttpContext httpContext)
    {
        var tenantHeaderValue = httpContext.Request.Headers[TenantHeaderIdentifier];
        
        return tenantHeaderValue == StringValues.Empty ? TenantProviderResult.Empty : new TenantProviderResult(tenantHeaderValue);
    }

    public string TenantHeaderIdentifier { get; init; } = "X-Tenant";
}