using BuildingBlocks.ApplicationPorts.Context;
using Complaints.Application.Abstractions.Persistence;
using Complaints.Domain;
using FluentValidation;
using SharedKernel.Messaging;

namespace Hivify.UseCases.Complaints.Commands.UpdateComplaintStatus;

public sealed class UpdateComplaintStatusCommandHandler
    : ICommandHandler<UpdateComplaintStatusCommand, bool>
{
    private readonly IComplaintRepo _complaintRepository;
    private readonly ICurrentUser _currentUser;
    private readonly IValidator<UpdateComplaintStatusCommand> _validator;

    public UpdateComplaintStatusCommandHandler(
        IComplaintRepo complaintRepository,
        ICurrentUser currentUser,
        IValidator<UpdateComplaintStatusCommand> validator)
    {
        _complaintRepository = complaintRepository;
        _currentUser = currentUser;
        _validator = validator;
    }

    public async Task<bool> Handle(
        UpdateComplaintStatusCommand command,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        await _validator.ValidateAndThrowAsync(command, cancellationToken);

        // Authorization – endast admin
        if (!await _currentUser.IsInRoleAsync("Admin"))
            throw new UnauthorizedAccessException("Endast administratörer kan ändra status.");

        var complaint = await _complaintRepository.GetComplaintByIdAsync(
            new ComplaintID(command.ComplaintId),
            cancellationToken);

        if (complaint == null)
            throw new KeyNotFoundException($"Complaint with ID {command.ComplaintId} not found.");

        // Uppdatera status
        complaint.UpdateStatus(command.Status);

        // Lägg till admin-kommentar om den finns
        if (!string.IsNullOrWhiteSpace(command.AdminComment))
        {
            complaint.AddAdminComment(command.AdminComment);
        }

        await _complaintRepository.UpdateComplaintAsync(complaint, cancellationToken);

        return true;
    }
}