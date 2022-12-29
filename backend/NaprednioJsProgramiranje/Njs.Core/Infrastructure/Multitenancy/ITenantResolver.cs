namespace Njs.Core.Shared.Multitenancy;

/// <summary>
/// Defines a contract that describes a service that resolves the current tenant from a collection of <see cref="ITenantProvider"/>s.
/// </summary>
public interface ITenantResolver
{
    /// <summary>
    /// Produces the resulting <see cref="TenantProviderResult"/> by evaluating the registered providers.
    /// </summary>
    /// <returns>The resulting <see cref="TenantProviderResult"/>.</returns>
    TenantProviderResult GetTenant();
}