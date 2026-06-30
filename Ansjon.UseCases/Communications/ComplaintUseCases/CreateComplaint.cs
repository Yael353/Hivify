using Ansjon.Core.Entities.Complaints;
using Ansjon.UseCases.Communications.DTOs.ComplaintsDto;
using Ansjon.UseCases.Communications.interfaes;
using FluentValidation;


namespace Ansjon.UseCases.Communications.ComplaintUseCases
{
    internal class CreateComplaint
    {
        private readonly IComplaintRepo _complaintRepo;
        private readonly IValidator<CreateComplaintDto> _validator;
        private readonly ICurrentUser _currentUser;

        public CreateComplaint(IComplaintRepo complaintRepo, IValidator<CreateComplaintDto> validator, ICurrentUser currentUser)
        {
            _complaintRepo = complaintRepo;
            _validator = validator;
            _currentUser = currentUser;
        }

        public async Task<Guid> CreateComplaintAsync(CreateComplaintDto input)
        {
            ArgumentNullException.ThrowIfNull(input);
            await _validator.ValidateAndThrowAsync(input);


            //kommentera bort när roller finns
            //Tilldela id för den som skapar klagomålet
            var authorId = _currentUser.Id;

            //if (string.IsNullOrEmpty(authorId))
            //{
            //    throw new InvalidOperationException("Användaren är inte inloggad.");
            //}

            var complaint = new Complaint(
                input.Title,
                input.Description,
                authorId
                );

            if (!string.IsNullOrEmpty(input.ImageUrl))
            {
                complaint.SetImage(input.ImageUrl);
            }

            await _complaintRepo.CreateComplaintAsync(complaint);

            return complaint.ComplaintId;
        }
    }
}
