namespace Njs.Core.Shared.Multitenancy;

/// <summary>
/// Represents the result of a <see cref="ITenantProvider"/>. 
/// </summary>
public sealed class TenantProviderResult
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TenantProviderResult"/> class.
    /// </summary>
    /// <param name="tenantId">A string that identifies the tenant.</param>
    public TenantProviderResult(string? tenantId)
    {
        TenantId = tenantId;
    }

    /// <summary>
    /// Gets a default <see cref="TenantProviderResult"/> with a <see langword="null" /> <see cref="TenantId"/>.
    /// </summary>
    public static readonly TenantProviderResult Empty = new(null);
    
    /// <summary>
    /// Gets a string that identifies the tenant.
    /// </summary>
    public string? TenantId { get; }
}