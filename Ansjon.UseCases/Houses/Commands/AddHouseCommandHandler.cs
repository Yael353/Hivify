using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Houses;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Houses.Commands;

public sealed class AddHouseCommandHandler : ICommandHandler<AddHouseCommand, HouseID>
{
    private readonly IHouseRepo _houseRepo;
    private readonly IAssociationRepository _associationRepo;

    public AddHouseCommandHandler(
        IHouseRepo houseRepo,
        IAssociationRepository associationRepo)
    {
        _houseRepo = houseRepo;
        _associationRepo = associationRepo;
    }

    public async Task<HouseID> Handle(AddHouseCommand command, CancellationToken cancellationToken)
    {
        var association = await _associationRepo.GetByIdAsync(command.AssociationId, cancellationToken);
        if (association is null)
            throw new InvalidOperationException("Association was not found.");

        var address = new Address(command.Address);
        var houseNumber = new HouseNumber(command.HouseNumber);
        var postalCode = new PostalCode(command.PostalCode);

        var house = House.Create(
            command.AssociationId,
            address,
            houseNumber,
            postalCode);

        await _houseRepo.AddAsync(house, cancellationToken);
        await _houseRepo.SaveChangesAsync(cancellationToken);

        return house.Id;
    }
}