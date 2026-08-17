using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.Aggregates.Houses;
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
                    MemberRole.GeneralMember,
                    new Title("Welcome to Ansjon"),
                    new Description("This is the first seeded feed.")));


            context.Feeds.Add(
                Feed.CreateFeed(
                    new MemberID(Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc")),
                    MemberRole.GeneralMember,
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

                new Address("Main Street"),
                new HouseNumber("10"),
                new PostalCode("21120"));


            var house2 = House.Create(

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