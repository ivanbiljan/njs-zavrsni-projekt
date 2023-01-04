namespace Njs.Core.Entities;

/// <summary>
/// Represents the base class for entities that can be modified or soft deleted.
/// </summary>
public abstract class AuditableEntityBase : EntityBase
{
    /// <summary>
    /// Gets or sets the date and time when the entity was modified. This value should be persisted in UTC format.
    /// </summary>
    public DateTime? ModifiedAtUtc { get; set; }
    
    /// <summary>
    /// Gets or sets the date and time when the entity was deleted. This value should be persisted in UTC format.
    /// </summary>
    public DateTime? ArchivedAtUtc { get; set; }
}