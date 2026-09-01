using Association.Domain;
using Hivify.Core.SharedKernel.ValuesObjects;
using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;

namespace Association.Application.Commands.AddAssociation;

public sealed class CreateAssociationCommandHandler : ICommandHandler<AddAssociationCommand, AssociationID>
{
    private readonly IAssociationRepo _associationRepository;

    public CreateAssociationCommandHandler(IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<AssociationID> Handle(AddAssociationCommand command, CancellationToken cancellationToken)
    {
        var association = Core.Associations.Domain.Association.Create(new Name(command.Name));

        await _associationRepository.AddAsync(association, cancellationToken);

        await _associationRepository.SaveChangesAsync(
            cancellationToken);

        return association.Id;
    }
}