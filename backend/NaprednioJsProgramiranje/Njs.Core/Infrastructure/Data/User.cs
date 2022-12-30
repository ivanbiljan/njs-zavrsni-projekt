namespace Njs.Core.Infrastructure.Data;

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