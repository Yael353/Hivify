using Association.Domain.Members;
using Hivify.Core.Aggregates.Associations;
using Hivify.Core.SharedKernel.ValuesObjects;
using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;

namespace Association.Application.Commands.AddStaffMember;

public sealed class AddStaffMemberCommandHandler : ICommandHandler<AddStaffMemberCommand, MemberID>
{
    private readonly IAssociationRepo _associationRepository;

    public AddStaffMemberCommandHandler(IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<MemberID> Handle(AddStaffMemberCommand command, CancellationToken cancellationToken)
    {
        var association = await _associationRepository.GetByIdAsync(new AssociationID(command.AssociationId), cancellationToken);

        if (association is null)
            throw new InvalidOperationException("Association was not found.");

        var member = association.CreateMember(new UserID(command.UserId), new Name(command.FullName), new Email(command.Email), command.Role);

        await _associationRepository.SaveChangesAsync(cancellationToken);

        return member.Id;
    }
}