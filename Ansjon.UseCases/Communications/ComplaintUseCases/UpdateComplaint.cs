using Ansjon.Core.Entities.Complaints;
using Ansjon.UseCases.Communications.DTOs.ComplaintsDto;
using Ansjon.UseCases.Communications.InterFaces;
using FluentValidation;

namespace Ansjon.UseCases.Communications.ComplaintUseCases
{
    public class UpdateComplaint
    {
        private readonly IComplaintRepo _complaintRepo;
        private readonly IValidator<UpdateComplaintDto> _validator;

        public UpdateComplaint(
            IComplaintRepo complaintRepo,
            IValidator<UpdateComplaintDto> validator)
        {
            _complaintRepo = complaintRepo;
            _validator = validator;
        }

        public async Task ExecuteAsync(Guid complaintId, UpdateComplaintDto input)
        {
            ArgumentNullException.ThrowIfNull(input);

            await _validator.ValidateAndThrowAsync(input);

            var complaint = await _complaintRepo.GetComplaintByIdAsync(complaintId);

            if (complaint == null)
            {
                throw new KeyNotFoundException($"Complaint with ID {complaintId} not found.");
            }

            complaint.UpdateDetails(input.Title, input.Description);

            if (!string.IsNullOrEmpty(input.ImageUrl))
            {
                complaint.SetImage(input.ImageUrl);
            }

            if (input.Status.HasValue)
            {
                complaint.UpdateStatus(input.Status.Value);
            }

            if (!string.IsNullOrEmpty(input.AdminComment))
            {
                complaint.AddAdminComment(input.AdminComment);
            }

            await _complaintRepo.UpdateComplaintAsync(complaint);
        }
    }
}