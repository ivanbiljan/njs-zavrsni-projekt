using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Njs.Core.Infrastructure.Data;

namespace Njs.Core.Infrastructure.Persistence.Configurations;

internal sealed class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasMany(c => c.Stores).WithOne(s => s.Currency).HasForeignKey(s => s.CurrencyId);
    }
}