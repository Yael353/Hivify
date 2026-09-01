using Hivify.Core.Aggregates.Houses;
using Hivify.Core.Aggregates.Houses.Tenants;
using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;

namespace Hivify.UseCases.Houses.Commands.DeleteTenant;

public sealed class RemoveHouseTenantCommandHandler
    : ICommandHandler<RemoveHouseTenantCommand, bool>
{
    private readonly IHouseRepo _houseRepo;

    public RemoveHouseTenantCommandHandler(
        IHouseRepo houseRepo)
    {
        _houseRepo = houseRepo;
    }

    public async Task<bool> Handle(
        RemoveHouseTenantCommand command,
        CancellationToken cancellationToken)
    {
        var house = await _houseRepo.GetByIdAsync(
            new HouseID(command.HouseId),
            cancellationToken);

        if (house is null)
            return false;

        house.RemoveTenant(
            new TenantID(command.TenantId));

        await _houseRepo.SaveChangesAsync(
            cancellationToken);

        return true;
    }
}