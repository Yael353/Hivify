using Association.Application.Abstractions;
using Hivify.Association.Domain.Associations;
using Hivify.Association.Domain.Members;
using SharedKernel.Messaging;
using SharedKernel.ValuesObjects;

namespace Hivify.Association.Application.Commands.AddStaffMember;

public sealed class AddStaffMemberCommandHandler : ICommandHandler<AddStaffMemberCommand, MemberID>
{
    private readonly IAssociationRepo _associationRepository;

    public AddStaffMemberCommandHandler(IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<MemberID> Handle(AddStaffMemberCommand command, CancellationToken cancellationToken)
    {
        var AssociationEntity = await _associationRepository.GetByIdAsync(new AssociationID(command.AssociationId), cancellationToken);

        if (AssociationEntity is null)
            throw new InvalidOperationException("AssociationEntity was not found.");

        var member = AssociationEntity.CreateMember(new UserID(command.UserId), new Name(command.FullName), new Email(command.Email), command.Role);

        await _associationRepository.SaveChangesAsync(cancellationToken);

        return member.Id;
    }
}


