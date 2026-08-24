using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Association.Commands.AddStaffMember;

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

        var member = association.CreateMember(new UserID(command.UserId), new Name(command.FullName), command.Role);

        await _associationRepository.SaveChangesAsync(cancellationToken);

        return member.Id;
    }
}