using Ansjon.Core.Aggregates.Associations;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Association.Commands.RemoveStaffMember;

public sealed class RemoveStaffMemberCommandHandler
    : ICommandHandler<RemoveStaffMemberCommand, bool>
{
    private readonly IAssociationRepo _associationRepository;

    public RemoveStaffMemberCommandHandler(
        IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<bool> Handle(
        RemoveStaffMemberCommand command,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var association = await _associationRepository.GetByIdAsync(
            new AssociationID(command.AssociationId),
            cancellationToken);

        if (association is null)
        {
            throw new KeyNotFoundException(
                $"Association {command.AssociationId} was not found.");
        }

        var member = association.StaffMembers
            .FirstOrDefault(member =>
                member.Id.Value == command.MemberId &&
                member.DeletedAt == null);

        if (member is null)
        {
            throw new KeyNotFoundException(
                $"Member {command.MemberId} was not found.");
        }

        association.RemoveMember(member);

        await _associationRepository.SaveChangesAsync(
            cancellationToken);

        return true;
    }
}