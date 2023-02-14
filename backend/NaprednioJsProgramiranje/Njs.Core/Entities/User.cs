using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Njs.Core.Entities;

public sealed class User : AuditableEntityBase
{
    private User()
    {
    }
    
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

    public ICollection<RefreshToken> RefreshTokens { get; init; } = new List<RefreshToken>();
}

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