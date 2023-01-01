namespace Njs.Core.Infrastructure;

public interface ICurrentUserService
{
    public string? UserId { get; }
}

internal sealed class ClaimsCurrentUserService : ICurrentUserService
{
    public string? UserId { get; }
}