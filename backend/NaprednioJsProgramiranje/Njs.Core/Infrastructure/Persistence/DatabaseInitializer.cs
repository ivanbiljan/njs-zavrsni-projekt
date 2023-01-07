using Bogus;
using Microsoft.EntityFrameworkCore;
using Njs.Core.Entities;
using Njs.Core.Features.Authentication;

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

        var currencies = new Currency[]
        {
            new()
            {
                Id = 1,
                Code = "EUR",
                Sign = "€",
                Formatting = 0,
                DecimalPlaces = 2,
                DecimalSeparator = ".",
                GroupSeparator = ","
            },
            new()
            {
                Id = 2,
                Code = "ISK",
                Sign = "kr.",
                Formatting = 3,
                DecimalPlaces = 0,
                DecimalSeparator = ",",
                GroupSeparator = "."
            }
        };

        modelBuilder.Entity<Currency>().HasData(currencies);

        var stores = new Store[]
        {
            new()
            {
                Id = 1,
                TenantId = ".1",
                CountryCode = "HR",
                DisplayName = "Croatia",
                CurrencyId = 1
            },
            new()
            {
                Id = 2,
                TenantId = ".2",
                CountryCode = "IS",
                DisplayName = "Iceland",
                CurrencyId = 2
            }
        };

        modelBuilder.Entity<Store>().HasData(stores);

        var categoryId = 1;
        var categories = new Faker<Category>()
            .RuleFor(c => c.Id, f => categoryId++)
            .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0])
            .RuleFor(c => c.Description, f => f.Lorem.Sentence())
            .RuleFor(c => c.LogoUrl, f => f.Image.PicsumUrl());

        modelBuilder.Entity<Category>().HasData(categories.GenerateBetween(10, 10));

        var productId = 1;
        var productFakerSpecification = new Faker<Product>()
            .RuleFor(p => p.Id, f => productId++)
            .RuleFor(p => p.StoreId, f => Random.Shared.Next(1, 3))
            .RuleFor(p => p.Title, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription());

        modelBuilder.Entity<Product>().HasData(productFakerSpecification.GenerateBetween(50, 150));
    }
}