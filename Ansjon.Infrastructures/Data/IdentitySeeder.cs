using Ansjon.Infrastructures.SqlDatabase;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.Infrastructures.Data;

public static class IdentitySeeder
{
    public static async Task SeedAsync(
        IServiceProvider services)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>
            {
                Name = "Admin"
            });
        }

        // Admin user

        var adminEmail = "admin@ansjon.com";

        var adminUser = await userManager.FindByEmailAsync(adminEmail);


        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };


            await userManager.CreateAsync(
                adminUser,
                "Admin123!");
        }


        // Assign role

        if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
        {
            await userManager.AddToRoleAsync(
                adminUser,
                "Admin");
        }
    }
}