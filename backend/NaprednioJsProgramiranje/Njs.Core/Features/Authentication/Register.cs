using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Njs.Core.Entities;
using Njs.Core.Exceptions;
using Njs.Core.Infrastructure.Persistence;
using PhoneNumbers;

namespace Njs.Core.Features.Authentication;

public record RegisterUserRequest
(string Email, string Username, string Password, string PhoneNumber, string? FirstName,
    string? LastName) : IRequest<RegisterUserResponse>;

public record RegisterUserResponse;

public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserRequest>
{
    private static readonly Regex EmailRegex = new(
        "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$");

    public RegisterUserCommandValidator()
    {
        RuleFor(r => r.Email).NotEmpty().WithMessage("Email is empty").Matches(EmailRegex).WithMessage("Invalid email address");
        RuleFor(r => r.Username).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Username is empty");
        RuleFor(r => r.FirstName).NotEmpty().WithMessage("First name is empty");
        RuleFor(r => r.LastName).NotEmpty().WithMessage("Last name is empty");
        RuleFor(r => r.Password).NotEmpty().WithMessage("Password is empty").MinimumLength(6)
            .WithMessage("Password must contain at least 6 characters");
    }
}

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
            .Where(u => u.Email == request.Email || u.Username == request.Username)
            .SingleOrDefaultAsync(cancellationToken);

        var categories = _db.Users.ToList();
        
        if (user is not null)
        {
            // Maybe?
            var validationErrors = new List<ValidationFailure>();
            if (user.Email == request.Email)
            {
                validationErrors.Add(new ValidationFailure(nameof(request.Email), "This email is already taken"));
            }
            
            if (user.Username == request.Username)
            {
                validationErrors.Add(new ValidationFailure(nameof(request.Username), "This username is already taken"));
            }

            throw new ValidationException(validationErrors);
        }

        PhoneNumber parsedPhoneNumber;

        try
        {
            parsedPhoneNumber = PhoneNumberUtil.Parse(request.PhoneNumber, Constants.DefaultPhoneRegion);
        }
        catch
        {
            throw new ValidationException("This is not a valid phone number");   
        }

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