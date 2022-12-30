namespace Njs.Core.Features.Authentication;

public sealed class JwtSettings
{
    public const string ConfigurationSectionName = "Jwt";
    
    public string Audience { get; init; }

    public string Issuer { get; init; }
    
    public string Key { get; init; }
}