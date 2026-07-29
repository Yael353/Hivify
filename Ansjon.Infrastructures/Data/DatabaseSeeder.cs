using Ansjon.Core.Aggregates.Association;
using Ansjon.Core.Aggregates.Association.Staff;
using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.Aggregates.Houses;
using Ansjon.Core.ValuesObjects;
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
                    new StaffMemberID(Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")),
                    StaffRole.Admin,
                    new Title("Welcome to Ansjon"),
                    new Description("This is the first seeded feed.")));


            context.Feeds.Add(
                Feed.CreateFeed(
                    new StaffMemberID(Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc")),
                    StaffRole.Admin,
                    new Title("Getting Started"),
                    new Description("Learn how to use the platform.")));
        }


        // Seed Association
        Association? association = null;

        if (!await context.Associations.AnyAsync())
        {
            association = Association.Create(
                "Ansjon Housing Association");

            context.Associations.Add(association);
        }
        else
        {
            association = await context.Associations.FirstAsync();
        }


        // Seed Houses
        if (!await context.Houses.AnyAsync())
        {
            var house1 = House.Create(
                association.Id,
                new Address("Main Street"),
                new HouseNumber("10"),
                new PostalCode("21120"));


            var house2 = House.Create(
                association.Id,
                new Address("Park Avenue"),
                new HouseNumber("25"),
                new PostalCode("21130"));


            context.Houses.AddRange(
                house1,
                house2);
        }


        await context.SaveChangesAsync();
    }
}