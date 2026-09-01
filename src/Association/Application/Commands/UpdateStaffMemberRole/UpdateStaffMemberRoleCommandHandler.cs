using Association.Application.Abstractions;
using Hivify.Association.Domain.Associations;
using Hivify.Association.Domain.Members;
using SharedKernel.Messaging;

namespace Hivify.Association.Application.Commands.UpdateStaffMemberRole;

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

        var AssociationEntity =
            await _associationRepository.GetByIdAsync(
                new AssociationID(command.AssociationId),
                cancellationToken);

        if (AssociationEntity is null)
        {
            throw new KeyNotFoundException(
                $"AssociationEntity {command.AssociationId} was not found.");
        }

        AssociationEntity.UpdateMemberRole(
            new MemberID(command.MemberId),
            command.Role);

        await _associationRepository.SaveChangesAsync(
            cancellationToken);

        return true;
    }
}


