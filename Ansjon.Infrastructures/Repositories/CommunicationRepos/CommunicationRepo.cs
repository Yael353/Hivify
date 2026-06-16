using Ansjon.Core.Entities;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Communications;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Repositories.CommunicationRepos
{
    public class CommunicationRepo : ICommunicationRepo
    {
        // db injection
        public Task CreateFeedAsync(Feed FeedRecord)
        {

        }
        public Task<IEnumerable<Feed>> GetAllFeedsAsync()
        {
            return await _context.Feeds.FindAsync(id);
        }

        public async Task<IEnumerable<Feed>> GetAllByDateAsync(DateTime CreatedDate)
        {
            return await _context.Feeds
                .Where(f => f.CreatedDate == CreatedDate.Date).ToListAsync();
        }

        
    }
}
