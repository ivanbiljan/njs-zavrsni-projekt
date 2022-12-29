using Microsoft.AspNetCore.Http;

namespace Njs.Core.Shared.Multitenancy;


public interface ITenantProvider
{
    TenantProviderResult? GetTenant(HttpContext httpContext);
}