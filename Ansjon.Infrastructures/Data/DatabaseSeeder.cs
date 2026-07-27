using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.ValuesObjects;
using Ansjon.Infrastructures.SqlDatabase;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Data;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Feeds.AnyAsync())
            return;

        context.Feeds.Add(
            Feed.CreateFeed(
                new AuthorID(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")),
                new Title("Welcome to Ansjon"),
                new Description("This is the first seeded feed.")));

        context.Feeds.Add(
            Feed.CreateFeed(
                new AuthorID(Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc")),
                new Title("Getting Started"),
                new Description("Learn how to use the platform.")));

        await context.SaveChangesAsync();
    }
}