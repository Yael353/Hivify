using Ansjon.Core.Entities.Complaint;

namespace Ansjon.UseCases.Communications.InterFaces
{
    public interface IComplaintRepo
    {
        Task CreateComplaintAsync(Complaint complaint);
        Task<IEnumerable<Complaint>> GetAllComplaintsAsync();
        Task<Complaint?> GetComplaintByIdAsync(Guid id);
        Task<IEnumerable<Complaint>> GetAllComplaintsByAuthorAsync(Guid authorId);
        Task UpdateComplaintAsync(Complaint complaint);
        Task DeleteComplaintByIdAsync(Guid id);
    }
}
