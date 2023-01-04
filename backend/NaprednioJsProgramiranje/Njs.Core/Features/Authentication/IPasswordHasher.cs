using Microsoft.AspNetCore.Identity;
using Njs.Core.Entities;

namespace Njs.Core.Features.Authentication;

public interface IPasswordHasher
{
    string Hash(string password);

    bool VerifyPassword(string providedPassword, string hashedPassword);
}

internal sealed class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<User> _passwordHasher = new();

    public bool VerifyPassword(string providedPassword, string hashedPassword) =>
        _passwordHasher.VerifyHashedPassword(null!, hashedPassword, providedPassword) ==
        PasswordVerificationResult.Success;

    public string Hash(string password) => _passwordHasher.HashPassword(null!, password);
}