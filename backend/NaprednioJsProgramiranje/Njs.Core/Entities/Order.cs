namespace Njs.Core.Entities;

public sealed class Order : EntityBase, IMustHaveTenant
{
    public int UserId { get; }
    
    public User User { get; }
    
    public int CurrencyId { get; }
    
    public Currency Currency { get; }
    
    public ICollection<OrderItem> Items { get; } = new List<OrderItem>();
    
    public string TenantId { get; set; }
}