using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Njs.Core.Entities;

public sealed class RefreshToken : AuditableEntityBase
{
    public string CreatedBy { get; set; }

    public DateTime ExpiresAt { get; set; }

    public bool IsActive => !ArchivedAtUtc.HasValue;

    public bool IsRevoked => string.IsNullOrWhiteSpace(RevokedBy);

    public User Owner { get; set; }

    public int OwnerId { get; set; }

    public string? RevokedBy { get; set; }
    
    public string Token { get; set; }
}

internal sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.Ignore(r => r.IsActive);
        builder.Ignore(r => r.IsRevoked);
    }
}