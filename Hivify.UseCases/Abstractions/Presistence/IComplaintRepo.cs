using Hivify.Core.Aggregates.Complaints;
using Hivify.Core.SharedKernel.ValuesObjects;

namespace Hivify.UseCases.Abstractions.Presistence
{
    public interface IComplaintRepo
    {
        // Commands
        Task CreateComplaintAsync(Complaint complaint, CancellationToken cancellationToken = default);
        Task UpdateComplaintAsync(Complaint complaint, CancellationToken cancellationToken = default);
        Task DeleteComplaintByIdAsync(ComplaintID id, CancellationToken cancellationToken = default);

        // Queries (admin)
        Task<IEnumerable<Complaint>> GetAllComplaintsAsync(CancellationToken cancellationToken = default);

        // Queries (user)
        Task<IEnumerable<Complaint>> GetComplaintsByUserAsync(UserID userId, CancellationToken cancellationToken = default);

        // Common
        Task<Complaint?> GetComplaintByIdAsync(ComplaintID id, CancellationToken cancellationToken = default);
    }
}
