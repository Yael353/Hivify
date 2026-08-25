using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.Infrastructures.SqlDatabase;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Data;

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
                    new Title("Welcome to Ansjon"),
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