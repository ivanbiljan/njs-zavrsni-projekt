using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Njs.Core.Features.Authentication;

public interface IJwtFactory
{
    string CreateJwt(IEnumerable<Claim> claims);
}

internal sealed class JwtFactory : IJwtFactory
{
    private readonly JwtSettings _jwtOptions;

    public JwtFactory(IOptions<JwtSettings> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public string CreateJwt(IEnumerable<Claim> claims)
    {
        var jwtHandler = new JwtSecurityTokenHandler();
        var securityToken = new JwtSecurityToken(
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Key)),
                SecurityAlgorithms.HmacSha256),
            expires: DateTime.UtcNow.AddDays(Constants.Jwt.AccessTokenExpirationDays),
            claims: claims
        );

        return jwtHandler.WriteToken(securityToken);
    }
}