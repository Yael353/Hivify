using Ansjon.Core.Aggregates.Houses.Complaints;
using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.UseCases.Communications.DTOs.ComplaintsDto;
using Ansjon.UseCases.Communications.InterFaces;
using FluentValidation;

namespace Ansjon.UseCases.Communications.ComplaintUseCases
{
    public class CreateComplaint
    {
        private readonly IComplaintRepo _complaintRepo;
        private readonly IValidator<CreateComplaintDto> _validator;

        public CreateComplaint(
            IComplaintRepo complaintRepo,
            IValidator<CreateComplaintDto> validator)
        {
            _complaintRepo = complaintRepo;
            _validator = validator;
        }

        public async Task<Guid> CreateComplaintAsync(CreateComplaintDto input, TenantID TenantId)
        {
            ArgumentNullException.ThrowIfNull(input);

            await _validator.ValidateAndThrowAsync(input);

            var complaint = Complaint.Create(
                input.Title,
                input.Description,
                TenantId);


            if (!string.IsNullOrEmpty(input.ImageUrl))
            {
                complaint.SetImage(input.ImageUrl);
            }

            await _complaintRepo.CreateComplaintAsync(complaint);

            return complaint.Id.Value;

        }
    }
}