using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Infrastructures.SqlDatabase;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.Infrastructures.Data;

public static class IdentitySeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var dbContext = services.GetRequiredService<ApplicationDbContext>();

        // Seed role
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>
            {
                Name = "Admin"
            });
        }

        // Seed admin user
        const string adminEmail = "admin@ansjon.com";

        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, "Admin123!");
        }

        // Assign role
        if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        // Seed feeds
        if (!await dbContext.Feeds.AnyAsync())
        {
            dbContext.Feeds.Add(
                Feed.CreateFeed(
                    new AuthorID(adminUser.Id),
                    "Welcome to Ansjon",
                    "This is the first seeded feed."));

            dbContext.Feeds.Add(
                Feed.CreateFeed(
                    new AuthorID(adminUser.Id),
                    "Getting Started",
                    "Learn how to use the platform."));

            await dbContext.SaveChangesAsync();
        }
    }
}