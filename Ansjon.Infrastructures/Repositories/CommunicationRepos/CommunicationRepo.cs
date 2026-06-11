using Ansjon.Core.Entities;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Communications;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Repositories.CommunicationRepos
{
    public class CommunicationRepo : ICommunicationRepo
    {
        private readonly ApplicationDbContext _context;

        public CommunicationRepo(ApplicationDbContext context)
        {
            _context = context;
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

        
    }
}
