using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Njs.Core.Entities;

public sealed class Product : AuditableEntityBase
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int StoreId { get; init; }
    
    public Store Store { get; init; }

    public ICollection<Category> Categories { get; } = new List<Category>();
}

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasMany(p => p.Categories).WithMany(c => c.Products);
        builder.HasOne(p => p.Store).WithMany(s => s.Products);
    }
}