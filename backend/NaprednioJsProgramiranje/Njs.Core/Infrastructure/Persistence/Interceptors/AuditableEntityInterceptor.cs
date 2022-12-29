using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Njs.Core.Infrastructure.Data;

namespace Njs.Core.Infrastructure.Persistence.Interceptors;

internal sealed class AuditableEntityInterceptor : SaveChangesInterceptor
{
    /// <inheritdoc />
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry.Entity is not AuditableEntityBase auditableEntity)
            {
                continue;
            }

            switch (entry.State)
            {
                case EntityState.Modified:
                {
                    auditableEntity.ModifiedAtUtc = DateTime.UtcNow;
                }

                    break;
                case EntityState.Deleted:
                {
                    entry.State = EntityState.Modified;
                    auditableEntity.ArchivedAtUtc = DateTime.UtcNow;
                }

                    break;
            }
        }

        return ValueTask.FromResult(result);
    }
}