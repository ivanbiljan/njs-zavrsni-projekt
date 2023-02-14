using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasMany(o => o.Items).WithOne(i => i.Order).HasForeignKey(i => i.OrderId);
    }
}