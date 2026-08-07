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
        

        var house = House.Create(
             new Address(command.Address),
             new HouseNumber(command.HouseNumber),
             new PostalCode(command.PostalCode));

        await _houseRepo.AddAsync(house, cancellationToken);
        await _houseRepo.SaveChangesAsync(cancellationToken);

        return house.Id;
    }
}
