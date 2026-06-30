using Ansjon.UseCases.Communications.InterFaces;

namespace Ansjon.UseCases.Communications.ComplaintUseCases
{
    public class DeleteComplaint
    {
        private readonly IComplaintRepo _complaintRepo;

        public DeleteComplaint(IComplaintRepo complaintRepo)
        {
            _complaintRepo = complaintRepo;
        }

        public async Task ExecuteAsync(Guid complaintId)
        {
            var complaint = await _complaintRepo.GetComplaintByIdAsync(complaintId);

            if (complaint == null)
            {
                throw new KeyNotFoundException($"Complaint with ID {complaintId} not found.");
            }

            await _complaintRepo.DeleteComplaintByIdAsync(complaintId);
        }
    }
}