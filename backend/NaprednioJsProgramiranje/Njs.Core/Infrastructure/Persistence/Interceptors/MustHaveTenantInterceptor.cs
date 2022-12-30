using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Njs.Core.Infrastructure.Data;
using Njs.Core.Infrastructure.Multitenancy;

namespace Njs.Core.Infrastructure.Persistence.Interceptors;

internal sealed class MustHaveTenantInterceptor : SaveChangesInterceptor
{
    private readonly TenantProviderResult _tenantProviderResult;

    public MustHaveTenantInterceptor(ITenantResolver tenantResolver)
    {
        _tenantProviderResult = tenantResolver.GetTenant();
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry.Entity is not IMustHaveTenant { TenantId: null } mustHaveTenant ||
                entry.State != EntityState.Added)
            {
                continue;
            }

            var tenantId = _tenantProviderResult.TenantId!;

            if (tenantId == Constants.InvalidTenantId)
            {
                entry.State = EntityState.Detached;
            }

            mustHaveTenant.TenantId = tenantId;
        }

        return ValueTask.FromResult(result);
    }
}