using Microsoft.AspNetCore.Http;

namespace Njs.Core.Infrastructure.Multitenancy;

internal sealed class TenantResolver : ITenantResolver
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IEnumerable<ITenantProvider> _providers;
    
    public TenantResolver(IHttpContextAccessor httpContextAccessor, IEnumerable<ITenantProvider> providers)
    {
        _httpContextAccessor = httpContextAccessor;
        _providers = providers;
    }

    /// <inheritdoc />
    public TenantProviderResult GetTenant()
    {
        foreach (var provider in _providers)
        {
            var tenant = provider.GetTenant(_httpContextAccessor.HttpContext);
            if (tenant == null)
            {
                continue;
            }

            return tenant;
        }

        return TenantProviderResult.Empty;
    }
}