using MediatR;
using Microsoft.EntityFrameworkCore;
using Njs.Core.Infrastructure.Data;
using Njs.Core.Infrastructure.Exceptions;
using Njs.Core.Infrastructure.Persistence;
using PhoneNumbers;

namespace Njs.Core.Features.Authentication;

public record RegisterUserRequest
(string Email, string Username, string Password, string PhoneNumber, string? FirstName,
    string? LastName) : IRequest<RegisterUserResponse>;

public record RegisterUserResponse;

public sealed class RegisterUserCommand : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    private static readonly PhoneNumberUtil PhoneNumberUtil = PhoneNumberUtil.GetInstance();
    
    private readonly NjsContext _db;
    private readonly IPasswordHasher _passwordHasher;

    public RegisterUserCommand(NjsContext db, IPasswordHasher passwordHasher)
    {
        _db = db;
        _passwordHasher = passwordHasher;
    }

    public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _db.Users
            .AsNoTracking()
            .Where(u => u.Email == request.Email)
            .SingleOrDefaultAsync(cancellationToken);

        if (user is not null)
        {
            throw new BadRequestException("User already exists");
        }

        var parsedPhoneNumber = PhoneNumberUtil.Parse(request.PhoneNumber, Constants.DefaultPhoneRegion);
        
        var hashedPassword = _passwordHasher.Hash(request.Password);
        
        var newUser = new User(
            request.Username,
            request.Email,
            hashedPassword,
            parsedPhoneNumber.CountryCode.ToString(),
            parsedPhoneNumber.NationalNumber.ToString());

        _db.Users.Add(newUser);

        await _db.SaveAsync(cancellationToken);

        return new RegisterUserResponse();
    }
}