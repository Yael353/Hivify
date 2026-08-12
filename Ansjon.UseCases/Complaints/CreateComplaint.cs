using Ansjon.Core.Aggregates.Complaints;
using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Complaints.DTOs;
using FluentValidation;

namespace Ansjon.UseCases.Complaints
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