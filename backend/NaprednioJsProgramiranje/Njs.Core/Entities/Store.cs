namespace Njs.Core.Entities;

public sealed class Store : EntityBase, IMustHaveTenant
{
    public string TenantId { get; set; }
    
    public string CountryCode { get; init; }
    
    public string DisplayName { get; init; }
    
    public int CurrencyId { get; init; }
    
    public Currency Currency { get; init; }

    public ICollection<Product> Products { get; init; } = new List<Product>();
}