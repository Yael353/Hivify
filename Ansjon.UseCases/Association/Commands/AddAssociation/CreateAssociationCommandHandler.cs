using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Association.Commands.AddAssociation;

public sealed class CreateAssociationCommandHandler : ICommandHandler<AddAssociationCommand, AssociationID>
{
    private readonly IAssociationRepo _associationRepository;

    public CreateAssociationCommandHandler(IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<AssociationID> Handle(AddAssociationCommand command, CancellationToken cancellationToken)
    {
        var association = Core.Aggregates.Associations.Association.Create(new Name(command.Name));

        await _associationRepository.AddAsync(association, cancellationToken);

        await _associationRepository.SaveChangesAsync(
            cancellationToken);

        return association.Id;
    }
}