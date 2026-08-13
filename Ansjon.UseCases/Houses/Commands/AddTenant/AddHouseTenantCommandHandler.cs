using Ansjon.Core.Aggregates.Houses;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Houses.Commands.AddTenant;

public sealed class AddHouseTenantCommandHandler : ICommandHandler<AddHouseTenantCommand, Guid>
{
    private readonly IHouseRepo _houseRepo;

    public AddHouseTenantCommandHandler(IHouseRepo houseRepo)
    {
        _houseRepo = houseRepo;
    }

    public async Task<Guid> Handle(AddHouseTenantCommand command, CancellationToken cancellationToken)
    {
        var house = await _houseRepo.GetByIdAsync(new HouseID(command.HouseId), cancellationToken);

        if (house is null)
            throw new InvalidOperationException(
                "House could not be found.");

        var tenant = house.AddTenant(
            new Name(command.FirstName),
            new Name(command.LastName),
            new Email(command.Email),
            new PhoneNumber(command.PhoneNumber));

        await _houseRepo.SaveChangesAsync(cancellationToken);

        return tenant.Id.Value;
    }
}