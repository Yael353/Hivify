using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Communications.InterFaces;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Repositories.FeedRepos
{
    public class FeedRepo : IFeedRepo
    {

        private readonly ApplicationDbContext _context;
        public FeedRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateFeedAsync(Feed feed)
        {
            _context.Feeds.Add(feed);
            await _context.SaveChangesAsync();

        }
        public async Task<IEnumerable<Feed>> GetAllFeedsAsync()
        {
            return await _context.Feeds.ToListAsync();
        }

        public async Task<Feed?> GetByIdAsync(Guid id)
        {
            return await _context.Feeds.FindAsync(id);
        }

        public async Task<IEnumerable<Feed>> GetAllByDateAsync(DateTime CreatedDate)
        {
            return await _context.Feeds
                .Where(f => f.CreatedDate == CreatedDate.Date).ToListAsync();
        }

        public async Task UpdateFeedAsync(Feed feed)
        {
            _context.Feeds.Update(feed);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFeedByIdAsync(Guid id)
        {
            var feed = await GetByIdAsync(id);
            if (feed != null)
            {
                _context.Feeds.Remove(feed);
                await _context.SaveChangesAsync();
            }
        }
    }
}
