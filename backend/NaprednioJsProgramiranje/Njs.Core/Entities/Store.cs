using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Njs.Core.Entities;

public sealed class Store : EntityBase, IMustHaveTenant
{
    public string TenantId { get; set; }
    
    public string CountryCode { get; init; }
    
    public string DisplayName { get; init; }
    
    public int CurrencyId { get; init; }
    
    public Currency Currency { get; init; }

    public ICollection<Product> Products { get; init; } = new List<Product>();
}

internal sealed class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasMany(s => s.Products).WithOne(p => p.Store).HasForeignKey(p => p.StoreId);
        builder.HasOne(s => s.Currency).WithMany(c => c.Stores).HasForeignKey(s => s.CurrencyId);
    }
}