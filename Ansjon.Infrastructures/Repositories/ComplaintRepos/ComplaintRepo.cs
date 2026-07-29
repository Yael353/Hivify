using Ansjon.Core.Aggregates.Complaints;
using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Abstractions.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Repositories.ComplaintRepos
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

        public async Task<IEnumerable<Complaint>> GetAllComplaintsByAuthorAsync(TenantID tenantId)
        {
            return await _context.Complaints
                .Where(c => c.TenantId == tenantId)
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