using Association.Application.Abstractions;
using Association.Application.Commands.AddAssociation;
using Hivify.Association.Domain.Associations;
using SharedKernel.Messaging;
using SharedKernel.ValuesObjects;

namespace Hivify.Association.Application.Commands.AddAssociation;

public sealed class CreateAssociationCommandHandler : ICommandHandler<AddAssociationCommand, AssociationID>
{
    private readonly IAssociationRepo _associationRepository;

    public CreateAssociationCommandHandler(IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<AssociationID> Handle(AddAssociationCommand command, CancellationToken cancellationToken)
    {
        var associationEntity = AssociationEntity.Create(new Name(command.Name));

        await _associationRepository.AddAsync(associationEntity, cancellationToken);

        await _associationRepository.SaveChangesAsync(cancellationToken);

        return associationEntity.Id;
    }
}
