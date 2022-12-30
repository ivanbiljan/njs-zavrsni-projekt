namespace Njs.Core.Infrastructure.Data;

public sealed class Store : EntityBase, IMustHaveTenant
{
    public string TenantId { get; set; }
    
    public string CountryCode { get; }
    
    public int CurrencyId { get; }
    
    public Currency Currency { get; }
}