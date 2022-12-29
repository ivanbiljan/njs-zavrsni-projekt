namespace Njs.Core.Infrastructure.Data;

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

/// <summary>
///     Represents a contract that describes an entity that must have a tenant associated with it. These entities are
///     always filtered by their tenant ID.
/// </summary>
public interface IMustHaveTenant
{
    /// <summary>
    ///     Gets or sets the unique tenant identifier.
    /// </summary>
    string TenantId { get; set; }
}

/// <summary>
/// Represents an end user.
/// </summary>
public sealed class User : AuditableEntityBase
{
    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    public string FirstName { get; set; }
    
    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Gets or sets the date of birth.
    /// </summary>
    public DateTime DateOfBirth { get; set; }
    
    /// <summary>
    /// Gets or sets the dialing code that represents the country the user has registered from.
    /// </summary>
    public string CountryCode { get; set; }
    
    /// <summary>
    /// Gets or sets the local phone number; i.e., anything after <see cref="CountryCode"/>.
    /// </summary>
    public string LocalPhoneNumber { get; set; }

    /// <summary>
    /// Gets the full phone number in +CountryCode Local format.
    /// </summary>
    public string FullPhoneNumber => $"{CountryCode} {LocalPhoneNumber}";
    
    /// <summary>
    /// Gets or sets the hashed password.
    /// </summary>
    public string HashedPassword { get; set; }
}