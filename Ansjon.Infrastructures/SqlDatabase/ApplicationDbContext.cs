using Ansjon.Core.Aggregates.Complaints;
using Ansjon.Core.Aggregates.Feeds;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.SqlDatabase;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Feed> Feeds { get; set; }
    public DbSet<Complaint> Complaints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Feed>().HasData(
            new
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Title = "Welcome to Ansjon",
                Content = "This is the first seeded feed.",
                CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                AuthorId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")
            },
            new
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Title = "Getting Started",
                Content = "Learn how to use the platform.",
                CreatedDate = new DateTime(2025, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                AuthorId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc")
            }
        );
    }
}