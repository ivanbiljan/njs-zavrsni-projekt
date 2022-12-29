namespace Njs.Core.Shared.Multitenancy;

/// <summary>
///     Represents a contract that describes a provider for determining the tenant context of an HTTP request.
/// </summary>
public interface ITenantProvider
{
    /// <summary>
    ///     Determines the current tenant for an HTTP request.
    /// </summary>
    /// <returns>The tenant ID, or <see langword="null" /> if no tenant exists.</returns>
    TenantProviderResult? GetTenant();
}