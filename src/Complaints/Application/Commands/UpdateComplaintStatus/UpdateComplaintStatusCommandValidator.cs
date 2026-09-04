using FluentValidation;

namespace Complaints.Application.Commands.UpdateComplaintStatus;

public sealed class UpdateComplaintStatusCommandValidator : AbstractValidator<UpdateComplaintStatusCommand>
{
    public UpdateComplaintStatusCommandValidator()
    {
        RuleFor(x => x.ComplaintId)
            .NotEmpty().WithMessage("Ärende-ID är obligatoriskt.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Ogiltig status.");

        RuleFor(x => x.AdminComment)
            .MaximumLength(1000).WithMessage("Kommentaren får vara max 1000 tecken.");
    }
}