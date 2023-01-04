namespace Njs.Core.Entities;

public sealed class OrderItem : EntityBase
{
    public int OrderId { get; private set; }
    
    public Order Order { get; private set; }
    
    public int ProductId { get; private set; }
    
    public Product Product { get; private set; }
    
    public decimal Value { get; private set; }
}