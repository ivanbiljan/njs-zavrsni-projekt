namespace Njs.Core.Infrastructure.Data;

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