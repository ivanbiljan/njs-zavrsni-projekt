using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Njs.Core.Infrastructure.Data;

namespace Njs.Core.Infrastructure.Persistence.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasMany(p => p.Categories).WithMany(c => c.Products);
        builder.HasOne(p => p.Store).WithMany(s => s.Products);
    }
}