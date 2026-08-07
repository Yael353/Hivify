using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Houses;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Houses.Commands;

public sealed class AddHouseCommandHandler : ICommandHandler<AddHouseCommand, HouseID>
{
    private readonly IHouseRepo _houseRepo;

    public AddHouseCommandHandler(
        IHouseRepo houseRepo)
    {
        _houseRepo = houseRepo;
    }

    public async Task<HouseID> Handle(AddHouseCommand command, CancellationToken cancellationToken)
    {
        

        var address = new Address(command.Address);
        var houseNumber = new HouseNumber(command.HouseNumber);
        var postalCode = new PostalCode(command.PostalCode);

        var house = House.Create(
            address,
            houseNumber,
            postalCode);

        await _houseRepo.AddAsync(house, cancellationToken);
        await _houseRepo.SaveChangesAsync(cancellationToken);

        return house.Id;
    }
}