using Ansjon.Core.Entities.Complaints;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Communications.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructure.Repositories.ComplaintRepos
{
    public class ComplaintRepo : IComplaintRepo
    {
        private readonly ApplicationDbContext _context;

        public ComplaintRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateComplaintAsync(Complaint complaint)
        {
            _context.Complaints.Add(complaint);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Complaint>> GetAllComplaintsAsync()
        {
            return await _context.Complaints
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }

        public async Task<Complaint?> GetComplaintByIdAsync(Guid id)
        {
            return await _context.Complaints.FindAsync(id);
        }

        public async Task<IEnumerable<Complaint>> GetAllComplaintsByAuthorAsync(string authorId)
        {
            return await _context.Complaints
                .Where(c => c.AuthorId == authorId)
                .OrderByDescending(c => c.CreatedDate)
                .ToListAsync();
        }

        public async Task UpdateComplaintAsync(Complaint complaint)
        {
            _context.Complaints.Update(complaint);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteComplaintByIdAsync(Guid complaintId)
        {
            var complaint = await GetComplaintByIdAsync(complaintId);
            if (complaint != null)
            {
                _context.Complaints.Remove(complaint);
                await _context.SaveChangesAsync();
            }
        }
    }
}