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

        modelBuilder.Entity<Complaint>()
            .Property(c => c.ComplaintId)
            .HasConversion(
                v => v.Value,
                v => new ComplaintID(v));

        modelBuilder.Entity<Feed>()
            .Property(f => f.FeedId)
            .HasColumnName("Id")
            .HasConversion(
                v => v.Value,
                v => new FeedID(v));

        modelBuilder.Entity<Feed>()
            .Property(f => f.AuthorId)
            .HasConversion(
                v => v.Value,
                v => new AuthorID(v));
    }
}