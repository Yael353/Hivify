using Ansjon.Core.Aggregates.Associations;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.AssociationUseCases.Commands.AddAssociation;

namespace Ansjon.UseCases.AssociationUseCases.Commands.CreateAssociation;

public sealed class CreateAssociationCommandHandler : ICommandHandler<AddAssociationCommand, AssociationID>
{
    private readonly IAssociationRepo _associationRepository;

    public CreateAssociationCommandHandler(
        IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<AssociationID> Handle(AddAssociationCommand command, CancellationToken cancellationToken)
    {
        var association = Core.Aggregates.Associations.Association.Create(command.Name);

        await _associationRepository.AddAsync(association, cancellationToken);

        await _associationRepository.SaveChangesAsync(
            cancellationToken);

        return association.Id;
    }
}