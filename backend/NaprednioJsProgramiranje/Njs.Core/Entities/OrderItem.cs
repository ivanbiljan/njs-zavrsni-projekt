namespace Njs.Core.Entities;

public sealed class OrderItem : EntityBase
{
    public int OrderId { get; init; }
    
    public Order Order { get; init; }
    
    public int ProductId { get; init; }
    
    public Product Product { get; init; }
    
    public decimal Value { get; init; }
}