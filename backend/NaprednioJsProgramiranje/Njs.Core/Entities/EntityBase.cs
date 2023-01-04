namespace Njs.Core.Entities;

/// <summary>
/// Represents the base class for a database entity.
/// </summary>
public abstract class EntityBase
{
    /// <summary>
    /// Gets a number that uniquely identifies the entity. This is the primary key.
    /// </summary>
    /// <remarks>Properties named Id are implicitly considered PKs in EF Core and therefore do not have to be configured as such.</remarks>
    public int Id { get; init; }

    /// <summary>
    /// Gets the date and time when the entity was created. This value is persisted in UTC format.
    /// </summary>
    public DateTime CreatedAtUtc { get; } = DateTime.UtcNow;
}