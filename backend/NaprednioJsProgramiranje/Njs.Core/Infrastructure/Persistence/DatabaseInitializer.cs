using Microsoft.EntityFrameworkCore;
using Njs.Core.Features.Authentication;
using Njs.Core.Infrastructure.Data;

namespace Njs.Core.Infrastructure.Persistence;

internal static class DatabaseInitializer
{
    public static void SeedData(ModelBuilder modelBuilder, IPasswordHasher passwordHasher)
    {
        var users = new User[]
        {
            new("Administrator", "admin@tvz.hr", passwordHasher.Hash("admin"), "+385", "xx yyyy zzz")
            {
                Id = 1
            }
        };

        modelBuilder.Entity<User>().HasData(users);
    }
}