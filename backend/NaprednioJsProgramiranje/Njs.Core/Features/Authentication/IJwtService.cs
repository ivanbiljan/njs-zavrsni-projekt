using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Njs.Core.Infrastructure;
using Njs.Core.Infrastructure.Data;
using Njs.Core.Infrastructure.Exceptions;
using Njs.Core.Infrastructure.Persistence;

namespace Njs.Core.Features.Authentication;

public interface IJwtService
{
    Task RevokeAsync(string token);
    Task<(string Token, string RefreshToken)> CreateTokenAsync(int userId);
    Task<(string Token, string RefreshToken)> RefreshTokenAsync(string token);
}

internal sealed class JwtService : IJwtService
{
    private readonly ICurrentUserService _currentUserService;
    private readonly NjsContext _db;
    private readonly IJwtFactory _jwtFactory;

    public JwtService(IJwtFactory jwtFactory, ICurrentUserService currentUserService, NjsContext db)
    {
        _currentUserService = currentUserService;
        _db = db;
        _jwtFactory = jwtFactory;
    }

    public async Task RevokeAsync(string token)
    {
        var refreshToken = await _db.RefreshTokens
            .Where(t => t.Token == token)
            .SingleOrDefaultAsync();

        if (refreshToken is null)
        {
            throw new NjsException("Invalid token");
        }

        if (!refreshToken.IsRevoked)
        {
            throw new NjsException("The token has been revoked");
        }

        if (!refreshToken.IsActive)
        {
            throw new NjsException("This token has expired");
        }

        refreshToken.ArchivedAtUtc = DateTime.UtcNow;
    }

    public Task<(string Token, string RefreshToken)> CreateTokenAsync(int userId)
    {
        var newAccessToken = CreateAccessToken(userId);
        var newRefreshToken = CreateRefreshToken(userId);

        return Task.FromResult((newAccessToken, newRefreshToken.Token));
    }

    public async Task<(string Token, string RefreshToken)> RefreshTokenAsync(string token)
    {
        var refreshToken = await _db.RefreshTokens
            .Where(t => t.Token == token)
            .SingleOrDefaultAsync();

        if (refreshToken == null)
        {
            throw new NjsException("Invalid token");
        }

        var ownerId = int.Parse(_currentUserService.UserId!);
        if (refreshToken.Owner.Id != ownerId)
        {
            throw new NjsException("Refresh token does not belong to this user");
        }

        if (!refreshToken.IsActive)
        {
            throw new NjsException("The token has expired");
        }

        if (!refreshToken.IsRevoked)
        {
            throw new NjsException("This token has been revoked");
        }

        return await CreateTokenAsync(ownerId);
    }

    private static RefreshToken CreateRefreshToken(int userId) =>
        new()
        {
            CreatedBy = userId.ToString(),
            ExpiresAt = DateTime.UtcNow.AddDays(Constants.Jwt.RefreshTokenExpirationDays),
            OwnerId = userId,
            Token = Guid.NewGuid().ToString()
        };

    private string CreateAccessToken(int userId)
    {
        var tenantId = _db.Users.AsNoTracking().Where(u => u.Id == userId).Single();
        
        return _jwtFactory.CreateJwt(new[]
        {
            new Claim(Constants.Claims.Sid, userId.ToString())
        });
    }
}