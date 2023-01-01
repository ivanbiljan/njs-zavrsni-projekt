using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Njs.Core.Infrastructure.Data;

namespace Njs.Core.Infrastructure.Persistence.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(
            u => new
            {
                u.Email,
                u.Username
            }).IsUnique();
        
        builder.Ignore(u => u.FullPhoneNumber);

        builder.HasMany(u => u.RefreshTokens).WithOne(t => t.Owner).HasForeignKey(t => t.OwnerId);
    }
}