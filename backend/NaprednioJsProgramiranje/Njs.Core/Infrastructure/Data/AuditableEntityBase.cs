namespace Njs.Core.Infrastructure.Data;

public abstract class AuditableEntityBase : EntityBase
{
    public DateTime? ModifiedAtUtc { get; set; } = DateTime.UtcNow;
}