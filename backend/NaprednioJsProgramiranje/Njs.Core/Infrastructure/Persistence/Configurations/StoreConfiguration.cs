﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Njs.Core.Infrastructure.Data;

namespace Njs.Core.Infrastructure.Persistence.Configurations;

internal sealed class StoreConfiguration : IEntityTypeConfiguration<Store>
{
    public void Configure(EntityTypeBuilder<Store> builder)
    {
        builder.HasMany(s => s.Products).WithOne(p => p.Store).HasForeignKey(p => p.StoreId);
        builder.HasOne(s => s.Currency).WithMany(c => c.Stores);
    }
}