using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Abstractions.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Repositories.FeedRepo;

public sealed class FeedRepo : IFeedRepo
{
    private readonly ApplicationDbContext _context;

    public FeedRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateFeedAsync(
        Feed feed,
        CancellationToken cancellationToken = default)
    {
        _context.Feeds.Add(feed);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Feed>> GetAllFeedsAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Feeds
            .Where(f => f.DeletedAt == null)
            .ToListAsync(cancellationToken);
    }

    public async Task<Feed?> GetByIdAsync(
        FeedID id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Feeds
            .FirstOrDefaultAsync(
                f => f.Id == id,
                cancellationToken);
    }

    public async Task<IEnumerable<Feed>> GetAllByDateAsync(
     DateTime createdDate,
     CancellationToken cancellationToken = default)
    {
        return await _context.Feeds
            .Where(f =>
                f.DeletedAt == null &&
                f.CreatedDate.Date == createdDate.Date)
            .ToListAsync(cancellationToken);
    }
    public async Task UpdateFeedAsync(
        Feed feed,
        CancellationToken cancellationToken = default)
    {
        _context.Feeds.Update(feed);

        await _context.SaveChangesAsync(cancellationToken);
    }
}