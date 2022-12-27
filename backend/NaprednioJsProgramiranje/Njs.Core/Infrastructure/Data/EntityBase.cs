namespace Njs.Core.Infrastructure.Data;

public abstract class EntityBase
{
    public int Id { get; }

    public DateTime CreatedAtUtc { get; } = DateTime.UtcNow;
}