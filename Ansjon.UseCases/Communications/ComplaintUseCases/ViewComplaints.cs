using Ansjon.Core.Aggregates.Complaints;
using Ansjon.UseCases.Communications.InterFaces;

namespace Ansjon.UseCases.Communications.ComplaintUseCases
{
    public class ViewComplaints
    {
        private readonly IComplaintRepo _complaintRepo;

        public ViewComplaints(IComplaintRepo complaintRepo)
        {
            _complaintRepo = complaintRepo;
        }

        public async Task<IEnumerable<Complaint>> GetAllComplaintsAsync()
        {
            return await _complaintRepo.GetAllComplaintsAsync();
        }

        public async Task<Complaint?> GetComplaintByIdAsync(Guid id)
        {
            return await _complaintRepo.GetComplaintByIdAsync(id);
        }

        public async Task<IEnumerable<Complaint>> GetComplaintsByAuthorAsync(TenantID tenantId)
        {
            return await _complaintRepo.GetAllComplaintsByAuthorAsync(tenantId);
        }
    }
}