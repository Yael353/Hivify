using Ansjon.Core.Aggregates.Feeds;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.SqlDatabase;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Feeds.AnyAsync())
            return;

        context.Feeds.Add(
            Feed.CreateFeed(
                Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                "Welcome to Ansjon",
                "This is the first seeded feed."));

        context.Feeds.Add(
            Feed.CreateFeed(
                Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                "Getting Started",
                "Learn how to use the platform."));

        await context.SaveChangesAsync();
    }
}