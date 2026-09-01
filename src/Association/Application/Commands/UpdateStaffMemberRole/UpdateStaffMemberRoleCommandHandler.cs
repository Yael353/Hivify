using Hivify.Core.Aggregates.Associations;
using Hivify.Core.Aggregates.Associations.Members;
using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;

namespace Association.Application.Commands.UpdateStaffMemberRole;

public sealed class UpdateStaffMemberRoleCommandHandler
    : ICommandHandler<UpdateStaffMemberRoleCommand, bool>
{
    private readonly IAssociationRepo _associationRepository;

    public UpdateStaffMemberRoleCommandHandler(
        IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<bool> Handle(
        UpdateStaffMemberRoleCommand command,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var association =
            await _associationRepository.GetByIdAsync(
                new AssociationID(command.AssociationId),
                cancellationToken);

        if (association is null)
        {
            throw new KeyNotFoundException(
                $"Association {command.AssociationId} was not found.");
        }

        association.UpdateMemberRole(
            new MemberID(command.MemberId),
            command.Role);

        await _associationRepository.SaveChangesAsync(
            cancellationToken);

        return true;
    }
}