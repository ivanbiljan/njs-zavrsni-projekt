using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Njs.Core.Entities;

public enum VerificationType
{
    AccountConfirmation,
    ForgotPassword
}

public sealed class VerificationRequest : EntityBase
{
    public VerificationRequest(int userId, VerificationType verificationType) : this(
        userId,
        verificationType,
        Guid.NewGuid().ToString())
    {
    }

    public VerificationRequest(int userId, VerificationType verificationType, string token)
    {
        UserId = userId;
        VerificationType = verificationType;
        Token = token;
    }

    public DateTime? ActivationTime { get; init; }

    public bool HasBeenActivated => ActivationTime.HasValue;

    public DateTime ExpirationTime { get; init; }

    public bool HasExpired => ExpirationTime < DateTime.UtcNow;

    public string Token { get; }

    public User User { get; init; }

    public int UserId { get; init; }

    public VerificationType VerificationType { get; set; }
}

internal sealed class VerificationRequestConfiguration : IEntityTypeConfiguration<VerificationRequest>
{
    public void Configure(EntityTypeBuilder<VerificationRequest> builder)
    {
        builder.Ignore(r => r.HasBeenActivated);
        builder.Ignore(r => r.HasExpired);
    }
}