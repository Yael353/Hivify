using Ansjon.Core.Aggregates.Associations.Staff;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Association.Commands;

namespace Ansjon.UseCases.Associations.Commands;

public sealed class AddStaffMemberCommandHandler : ICommandHandler<AddStaffMemberCommand, StaffMemberID>
{
    private readonly IAssociationRepository _associationRepository;

    public AddStaffMemberCommandHandler(IAssociationRepository associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<StaffMemberID> Handle(AddStaffMemberCommand command, CancellationToken cancellationToken)
    {
        var association = await _associationRepository.GetByIdAsync(command.AssociationId, cancellationToken);

        if (association is null)
            throw new InvalidOperationException("Association was not found.");

        var member = association.CreateMember(command.FullName, command.Role);

        await _associationRepository.SaveChangesAsync(cancellationToken);

        return member.Id;
    }
}