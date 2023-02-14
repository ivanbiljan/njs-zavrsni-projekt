using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Njs.Core.Entities;

public sealed class Currency : EntityBase
{
    public string Code { get; init; }
    
    public string Sign { get; init; }
    
    public int Formatting { get; init; }
    
    public int DecimalPlaces { get; init; }
    
    public string DecimalSeparator { get; init; }
    
    public string GroupSeparator { get; init; }

    public ICollection<Store> Stores { get; init; } = new List<Store>();
}

internal sealed class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasMany(c => c.Stores).WithOne(s => s.Currency).HasForeignKey(s => s.CurrencyId);
    }
}