using MediatR;
using Microsoft.EntityFrameworkCore;
using Njs.Core.Exceptions;
using Njs.Core.Infrastructure.Persistence;

namespace Njs.Core.Features.Authentication;

public record LoginUserRequest(string Username, string Password) : IRequest<LoginUserResponse>;

public record LoginUserResponse(string AccessToken, string RefreshToken);

public sealed class LoginCommand : IRequestHandler<LoginUserRequest, LoginUserResponse>
{
    private readonly NjsContext _db;
    private readonly IJwtService _jwtService;
    private readonly IPasswordHasher _passwordHasher;

    public LoginCommand(NjsContext db, IPasswordHasher passwordHasher, IJwtService jwtService)
    {
        _db = db;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _db.Users
            .AsNoTracking()
            .Where(u => u.Email == request.Username || u.Username == request.Username)
            .SingleOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            throw new NjsException("User does not exist");
        }

        // if (user.ActivationTime is null)
        // {
        //     throw new BadRequestException("The account has not been activated");
        // }

        if (!_passwordHasher.VerifyPassword(request.Password, user.HashedPassword))
        {
            throw new NjsException("Invalid password");
        }

        var (accessToken, refreshToken) = await _jwtService.CreateTokenAsync(user.Id);

        return new LoginUserResponse(accessToken, refreshToken);
    }
}