using Ansjon.Core.Aggregates.Complaints;
using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.AppValues;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.SqlDatabase;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Feed> Feeds => Set<Feed>();
    public DbSet<Complaint> Complaints => Set<Complaint>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Complaint
        modelBuilder.Entity<Complaint>()
            .Property(c => c.Id)
            .HasConversion(
                id => id.Value,
                value => new ComplaintID(value));

        modelBuilder.Entity<Complaint>()
            .Property(c => c.TenantId)
            .HasConversion(
                id => id.Value,
                value => new TenantID(value));

        // Feed
        modelBuilder.Entity<Feed>()
            .Property(f => f.Id)
            .HasConversion(
                id => id.Value,
                value => new FeedID(value));

        modelBuilder.Entity<Feed>()
            .Property(f => f.AuthorId)
            .HasConversion(
                id => id.Value,
                value => new AuthorID(value));

        modelBuilder.Entity<Feed>()
            .Property(f => f.Title)
            .HasConversion(
                title => title.Value,
                value => new Title(value))
            .HasMaxLength(200);

        modelBuilder.Entity<Feed>()
            .Property(f => f.Content)
            .HasConversion(
                content => content.Value,
                value => new Description(value))
            .HasMaxLength(1000);
    }
}