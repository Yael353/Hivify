using Hivify.Core.Feeds;
using Hivify.Core.SharedKernel.ValuesObjects;
using Hivify.Infrastructures.SqlDatabase;
using Microsoft.EntityFrameworkCore;

namespace Hivify.Infrastructures.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        // Seed Feeds
        if (!await context.Feeds.AnyAsync())
        {
            context.Feeds.Add(
                Feed.CreateFeed(
                    new UserID(Guid.Parse(
                        "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")),
                    new Title("Welcome to Hivify"),
                    new Description("This is the first seeded feed.")));

            context.Feeds.Add(
                Feed.CreateFeed(
                    new UserID(Guid.Parse(
                        "cccccccc-cccc-cccc-cccc-cccccccccccc")),
                    new Title("Getting Started"),
                    new Description("Learn how to use the platform.")));
        }

        await context.SaveChangesAsync();

        // Seed Houses
        await HouseSeeder.SeedAsync(context);
    }
}