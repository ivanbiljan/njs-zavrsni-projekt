using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Njs.Core.Infrastructure.Data;

namespace Njs.Core.Infrastructure.Persistence.Configurations;

internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasMany(o => o.Items).WithOne(i => i.Order).HasForeignKey(i => i.OrderId);
    }
}