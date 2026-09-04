using Complaints.Domain;
using FluentValidation;
using SharedKernel.Messaging;

namespace Hivify.UseCases.Complaints.Commands.CreateComplaint;

public sealed class CreateComplaintCommandHandler : ICommandHandler<CreateComplaintCommand, Guid>
{
    private readonly IComplaintRepo _complaintRepository;
    private readonly ICurrentUser _currentUser;
    private readonly IValidator<CreateComplaintCommand> _validator;

    public CreateComplaintCommandHandler(
        IComplaintRepo complaintRepository,
        IUserRepo userRepository,
        ICurrentUser currentUser,
        IValidator<CreateComplaintCommand> validator)
    {
        _complaintRepository = complaintRepository;
        _currentUser = currentUser;
        _validator = validator;
    }

    public async Task<Guid> Handle(CreateComplaintCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        await _validator.ValidateAndThrowAsync(command, cancellationToken);

        var userId = await _currentUser.GetUserIdAsync();



        var complaint = Complaint.Create(
            new UserID(userId),
            command.Category,
            new Title(command.Title),
            new Description(command.Description),
            command.ImageUrl);

        await _complaintRepository.CreateComplaintAsync(complaint, cancellationToken);

        return complaint.Id.Value;
    }
}