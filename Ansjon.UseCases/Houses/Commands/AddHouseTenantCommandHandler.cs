using Ansjon.Core.Aggregates.Houses;
using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Core.SharedKernel;
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

        var firstName = new Name(command.FirstName);
        var lastName = new Name(command.LastName);
        var email = new Email(command.Email);
        var phoneNumber = new PhoneNumber(command.PhoneNumber);

        var tenant = house.AddTenant(
            firstName,
            lastName,
            email,
            phoneNumber);

        await _houseRepo.SaveChangesAsync(cancellationToken);

        return tenant.Id;
    }
}