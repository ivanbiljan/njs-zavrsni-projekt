using Microsoft.AspNetCore.Http;

namespace Njs.Core.Infrastructure.Multitenancy;


public interface ITenantProvider
{
    TenantProviderResult? GetTenant(HttpContext httpContext);
}