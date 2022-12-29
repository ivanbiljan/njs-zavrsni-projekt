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

public interface IMustHaveTenant
{
    string TenantId { get; set; }
}

public sealed class User : AuditableEntityBase
{
    public User(string username, string email, string password, string countryCode, string localPhoneNumber)
    {
        Username = username;
        Email = email;
        HashedPassword = password;
        CountryCode = countryCode;
        LocalPhoneNumber = localPhoneNumber;
    }
    
    public string Username { get; init; }
    
    public string Email { get; set; }
    
    public string? FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public DateTime? DateOfBirth { get; set; }
    
    public string CountryCode { get; set; }
    
    public string LocalPhoneNumber { get; set; }
    
    public string FullPhoneNumber => $"{CountryCode} {LocalPhoneNumber}";
    
    public string HashedPassword { get; set; }
}