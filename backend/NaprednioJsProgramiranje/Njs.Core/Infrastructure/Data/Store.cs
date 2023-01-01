using System.Collections;

namespace Njs.Core.Infrastructure.Data;

public sealed class Store : EntityBase, IMustHaveTenant
{
    public string TenantId { get; set; }
    
    public string CountryCode { get; private set; }
    
    public int CurrencyId { get; private set; }
    
    public Currency Currency { get; private set; }

    public ICollection<Product> Products { get; private set; } = new List<Product>();
}