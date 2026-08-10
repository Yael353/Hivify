using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Houses.Commands;

public sealed class AddHouseTenantCommandHandler : ICommandHandler<AddHouseTenantCommand, TenantID>
{
    private readonly IHouseRepo _houseRepo;

    public AddHouseTenantCommandHandler(IHouseRepo houseRepo)
    {
        _houseRepo = houseRepo;
    }

    public async Task<TenantID> Handle(AddHouseTenantCommand command, CancellationToken cancellationToken)
    {
        var house = await _houseRepo.GetByIdAsync(command.HouseId, cancellationToken);
        if (house is null)
            throw new InvalidOperationException("House was not found.");

        var tenant = house.AddTenant(
             new Name(command.FirstName),
             new Name(command.LastName),
             new Email(command.Email),
             new PhoneNumber(command.PhoneNumber));

        await _houseRepo.SaveChangesAsync(cancellationToken);

        return tenant.Id;
    }
}
