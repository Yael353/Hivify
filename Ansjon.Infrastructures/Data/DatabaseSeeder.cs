using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Associations.Members;
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
                    new MemberID(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")),
                    MemberRole.StyrelseLedamot,
                    new Title("Welcome to Ansjon"),
                    new Description("This is the first seeded feed.")));

            context.Feeds.Add(
                Feed.CreateFeed(
                    new MemberID(Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc")),
                    MemberRole.StyrelseLedamot,
                    new Title("Getting Started"),
                    new Description("Learn how to use the platform.")));
        }

        // Seed Association
        Association? association = null;

        if (!await context.Associations.AnyAsync())
        {
            association = Association.Create("Ansjon Housing Association");

            context.Associations.Add(association);
        }
        else
        {
            association = await context.Associations.FirstAsync();
        }

        await context.SaveChangesAsync();

        // Seed Houses
        await HouseSeeder.SeedAsync(context);
    }
}