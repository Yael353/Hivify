using Houses.Domain.Houses;
using Microsoft.EntityFrameworkCore;

namespace Houses.Infrastructure.Presistence;

public sealed class HouseDbContext : DbContext
{
    public HouseDbContext(DbContextOptions<HouseDbContext> options)
        : base(options)
    {
    }

    public DbSet<House> Houses => Set<House>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(HouseDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}