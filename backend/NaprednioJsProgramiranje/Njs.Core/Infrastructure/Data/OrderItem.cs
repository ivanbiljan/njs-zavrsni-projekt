namespace Njs.Core.Infrastructure.Data;

public sealed class OrderItem : EntityBase
{
    public int OrderId { get; }
    
    public Order Order { get; }
    
    public decimal Value { get; }
}