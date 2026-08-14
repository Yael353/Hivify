using Ansjon.Core.Aggregates.Houses;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Houses.Commands.AddTenant;

public sealed class AddHouseTenantCommandHandler
    : ICommandHandler<AddHouseTenantCommand, Guid>
{
    private readonly IHouseRepo _houseRepo;
    private readonly IUserManagementService _userManagementService;

    public AddHouseTenantCommandHandler(
        IHouseRepo houseRepo,
        IUserManagementService userManagementService)
    {
        _houseRepo = houseRepo;
        _userManagementService = userManagementService;
    }

    public async Task<Guid> Handle(
        AddHouseTenantCommand command,
        CancellationToken cancellationToken)
    {
        var user = await _userManagementService.GetUserByIdAsync(
            command.UserId,
            cancellationToken);

        if (user is null)
            throw new InvalidOperationException(
                "The selected user does not exist.");

        var house = await _houseRepo.GetByIdAsync(
            new HouseID(command.HouseId),
            cancellationToken);

        if (house is null)
            throw new InvalidOperationException(
                "House could not be found.");

        var tenant = house.AddTenant(
            new UserID(command.UserId));

        await _houseRepo.SaveChangesAsync(
            cancellationToken);

        return tenant.Id.Value;
    }
}