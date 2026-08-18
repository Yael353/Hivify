using Ansjon.Core.Aggregates.Complaints;
using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using FluentValidation;

namespace Ansjon.UseCases.Complaints.Commands;

public sealed class CreateComplaintCommandHandler : ICommandHandler<CreateComplaintCommand, Guid>
{
    private readonly IComplaintRepo _complaintRepository;
    private readonly ITenantRepo _tenantRepository;
    private readonly ICurrentUser _currentUser;
    private readonly IValidator<CreateComplaintCommand> _validator;

    public CreateComplaintCommandHandler(
        IComplaintRepo complaintRepository,
        ITenantRepo tenantRepository,
        ICurrentUser currentUser,
        IValidator<CreateComplaintCommand> validator)
    {
        _complaintRepository = complaintRepository;
        _tenantRepository = tenantRepository;
        _currentUser = currentUser;
        _validator = validator;
    }

    public async Task<Guid> Handle(CreateComplaintCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        // 1. Validera kommandot
        await _validator.ValidateAndThrowAsync(command, cancellationToken);

        // 2. Hämta användarens ID
        var userId = await _currentUser.GetUserIdAsync();

        // 3. Försök hitta Tenant (om användaren är boende)
        TenantID? tenantId = null;
        var tenant = await _tenantRepository.GetByUserIdAsync(new UserID(userId), cancellationToken);
        if (tenant != null)
        {
            tenantId = tenant.Id;
        }

        // 4. Skapa complaint
        var complaint = Complaint.Create(
            new UserID(userId),
            tenantId,
            command.Category,
            new Title(command.Title),
            new Description(command.Description),
            command.ImageUrl);

        // 5. Spara i databasen
        await _complaintRepository.CreateComplaintAsync(complaint, cancellationToken);

        return complaint.Id.Value;
    }
}