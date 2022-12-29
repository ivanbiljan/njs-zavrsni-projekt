namespace Njs.Core.Shared.Multitenancy;

/// <summary>
/// Represents the default implementation of the <see cref="ITenantResolver"/> interface.
/// </summary>
internal sealed class TenantResolver : ITenantResolver
{
    private readonly IEnumerable<ITenantProvider> _providers;

    /// <summary>
    /// Initializes a new instance of the <see cref="TenantResolver"/> class.
    /// </summary>
    /// <param name="providers">A collection of <see cref="ITenantProvider"/> objects that can be used to extract the current tenant.</param>
    public TenantResolver(IEnumerable<ITenantProvider> providers)
    {
        _providers = providers;
    }

    /// <inheritdoc />
    public TenantProviderResult GetTenant()
    {
        foreach (var provider in _providers)
        {
            var tenant = provider.GetTenant();
            if (tenant == null)
            {
                continue;
            }

            return tenant;
        }

        return TenantProviderResult.Empty;
    }
}