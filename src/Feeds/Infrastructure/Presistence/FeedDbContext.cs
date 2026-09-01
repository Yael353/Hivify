using Feeds.Domain.Feeds;
using Microsoft.EntityFrameworkCore;

namespace Feeds.Infrastructure.Presistence;

public sealed class FeedDbContext : DbContext
{
    public FeedDbContext(DbContextOptions<FeedDbContext> options)
        : base(options)
    {
    }

    public DbSet<Feed> Feeds => Set<Feed>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(FeedDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}