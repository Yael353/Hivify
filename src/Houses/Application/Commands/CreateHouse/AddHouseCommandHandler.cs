using Hivify.UseCases.Abstractions.Presistence;
using Houses.Domain.Houses;
using SharedKernel.Messaging;



namespace Houses.Application.Commands.CreateHouse;

public sealed class AddHouseCommandHandler
    : ICommandHandler<AddHouseCommand, Guid>
{
    private readonly IHouseRepo _houseRepo;

    public AddHouseCommandHandler(
        IHouseRepo houseRepo)
    {
        _houseRepo = houseRepo;
    }

    public async Task<Guid> Handle(
        AddHouseCommand command,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        var house = House.Create(
            new Address(command.Address),
            new HouseNumber(command.HouseNumber),
            new PostalCode(command.PostalCode));

        await _houseRepo.AddAsync(
            house,
            cancellationToken);

        await _houseRepo.SaveChangesAsync(
            cancellationToken);

        return house.Id.Value;
    }
}