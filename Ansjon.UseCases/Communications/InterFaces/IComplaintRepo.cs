using Ansjon.Core.Entities.Complaints;


namespace Ansjon.UseCases.Communications.InterFaces
{
    public interface IComplaintRepo
    {
        Task CreateComplaintAsync(Complaint complaint);
        Task<IEnumerable<Complaint>> GetAllComplaintsAsync();
        Task<Complaint?> GetComplaintByIdAsync(Guid id);
        Task<IEnumerable<Complaint>> GetAllComplaintsByAuthorAsync(string authorId);
        Task UpdateComplaintAsync(Complaint complaint);
        Task DeleteComplaintByIdAsync(Guid id);
    }
}
