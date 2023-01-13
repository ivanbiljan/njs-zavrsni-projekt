using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using Njs.Core.Entities;
using Njs.Core.Features.Authentication;
using Njs.Core.Infrastructure.Persistence.Interceptors;
using Njs.Core.Infrastructure.Multitenancy;

namespace Njs.Core.Infrastructure.Persistence;

public sealed class NjsContext : DbContext
{
    private readonly ITenantResolver _tenantResolver;
    private readonly string _tenantId;
    private readonly IPasswordHasher _passwordHasher;

    public NjsContext(DbContextOptions<NjsContext> options, ITenantResolver tenantResolver, IPasswordHasher passwordHasher) : base(options)
    {
        _tenantResolver = tenantResolver;
        _passwordHasher = passwordHasher;
        
        _tenantId = tenantResolver.GetTenant().TenantId ?? Constants.InvalidTenantId;
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Store> Stores => Set<Store>();
    
    public DbSet<Currency> Currencies => Set<Currency>();
    
    public DbSet<Category> Categories => Set<Category>();
    
    public DbSet<Product> Products => Set<Product>();
    
    public DbSet<Order> Orders => Set<Order>();
    
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

    public Task<int> SaveAsync(CancellationToken cancellationToken) => SaveChangesAsync(cancellationToken);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.AddInterceptors(
            new AuditableEntityInterceptor(),
            new MustHaveTenantInterceptor(_tenantResolver)
        );
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<decimal>().HavePrecision(2);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NjsContext).Assembly);
        ConfigureGlobalFilters(modelBuilder);

        DatabaseInitializer.SeedData(modelBuilder, _passwordHasher);
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

            AddFilter(entityType, filter);
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

            AddFilter(entityType, filter);
        }
        
        void AddFilter(IMutableEntityType entityType, LambdaExpression expression)
        {
            var entityClrTypeExpression = Expression.Parameter(entityType.ClrType);

            var filter = ReplacingExpressionVisitor.Replace(
                expression.Parameters.Single(),
                entityClrTypeExpression,
                expression.Body);

            var oldFilterLambda = entityType.GetQueryFilter();
                
            if (oldFilterLambda != null)
            {
                var oldFilter = ReplacingExpressionVisitor.Replace(
                    oldFilterLambda.Parameters.Single(),
                    entityClrTypeExpression,
                    oldFilterLambda.Body);

                filter = Expression.AndAlso(filter, oldFilter);
            }

            var lambdaExpression = Expression.Lambda(filter, entityClrTypeExpression);
            entityType.SetQueryFilter(lambdaExpression);
            Console.WriteLine(lambdaExpression);
        }
    }
}