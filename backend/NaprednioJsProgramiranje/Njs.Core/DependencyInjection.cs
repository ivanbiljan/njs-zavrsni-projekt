using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Njs.Core.Features.Authentication;
using Njs.Core.Infrastructure;
using Njs.Core.Infrastructure.Multitenancy;
using Njs.Core.Infrastructure.Persistence;

namespace Njs.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddNjs(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
    {
        services.AddDbContext<NjsContext>(opts =>
        {
            if (environment.IsDevelopment())
            {
                opts.EnableDetailedErrors();
                opts.EnableSensitiveDataLogging();
                opts.ConfigureWarnings(warnings =>
                {
                    warnings.Log(
                        CoreEventId.FirstWithoutOrderByAndFilterWarning,
                        CoreEventId.RowLimitingOperationWithoutOrderByWarning,
                        CoreEventId.StartedTracking);
                });
            }
            
            var connectionString = configuration.GetConnectionString(nameof(NjsContext));
            // opts.UseSqlServer(connectionString, sqlServerOptions =>
            // {
            //     // Performs up to 6 retries 30 seconds apart (19.8.2022.)
            //     sqlServerOptions.EnableRetryOnFailure();
            // });
            opts.UseInMemoryDatabase("Balls");
        });

        // services.AddHttpClient();
        // services.AddHttpContextAccessor();
        
        services.AddScoped<ICurrentUserService, ClaimsCurrentUserService>();

        services.AddScoped<IJwtFactory, JwtFactory>();
        services.AddScoped<IJwtService, JwtService>();

        services.AddScoped<ITenantResolver, TenantResolver>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}