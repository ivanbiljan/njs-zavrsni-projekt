using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Njs.Core.Infrastructure.Data;
using Njs.Core.Infrastructure.Persistence.Interceptors;
using Njs.Core.Shared.Multitenancy;

namespace Njs.Core.Infrastructure.Persistence;

public sealed class GyroContext : DbContext
{
    private readonly ITenantResolver _tenantResolver;
    private readonly string _tenantId;

    public GyroContext(DbContextOptions<GyroContext> options, ITenantResolver tenantResolver) : base(options)
    {
        _tenantResolver = tenantResolver;
        
        // TenantId can only be null in the case of an unauthorized call or a malicious attack
        _tenantId = tenantResolver.GetTenant().TenantId ?? Constants.InvalidTenantId;
    }

    public DbSet<User> Users => Set<User>();

    public Task<int> SaveAsync(CancellationToken cancellationToken) => SaveChangesAsync(cancellationToken);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.AddInterceptors(
            new AuditableEntityInterceptor(),
            new MustHaveTenantInterceptor(_tenantResolver)
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GyroContext).Assembly);
        ConfigureGlobalFilters(modelBuilder);
    }

    private void ConfigureGlobalFilters(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            ConfigureTenantFilter(entityType);
            ConfigureArchivedFilter(entityType);
        }

        void ConfigureTenantFilter(IMutableEntityType entityType)
        {
            if (!typeof(IMustHaveTenant).IsAssignableFrom(entityType.ClrType))
            {
                return;
            }

            var entity = Expression.Parameter(entityType.ClrType, "e");
            var tenantId = Expression.PropertyOrField(entity, nameof(IMustHaveTenant.TenantId));
            var filter =
                Expression.Lambda(Expression.Equal(tenantId, Expression.Constant(_tenantId)),
                    entity);

            entityType.SetQueryFilter(filter);
        }

        void ConfigureArchivedFilter(IMutableEntityType entityType)
        {
            if (!typeof(AuditableEntityBase).IsAssignableFrom(entityType.ClrType))
            {
                return;
            }

            var entity = Expression.Parameter(entityType.ClrType, "e");
            var archiveDate = Expression.PropertyOrField(entity, nameof(AuditableEntityBase.ArchivedAtUtc));
            var filter =
                Expression.Lambda(Expression.Equal(archiveDate, Expression.Constant(null)),
                    entity);

            entityType.SetQueryFilter(filter);
        }
    }
}