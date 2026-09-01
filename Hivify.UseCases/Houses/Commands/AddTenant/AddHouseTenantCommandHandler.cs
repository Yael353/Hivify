using Hivify.Core.Aggregates.Houses;
using Hivify.Core.SharedKernel.ValuesObjects;
using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;
using Hivify.UseCases.Houses.Commands.AddTenant;

public sealed class AddHouseTenantCommandHandler : ICommandHandler<AddHouseTenantCommand, Guid>
{
    private readonly IHouseRepo _houseRepo;
    private readonly IUserRepo _userManagementService;

    public AddHouseTenantCommandHandler(IHouseRepo houseRepo, IUserRepo userManagementService)
    {
        _houseRepo = houseRepo;
        _userManagementService = userManagementService;
    }

    public async Task<Guid> Handle(AddHouseTenantCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManagementService.GetUserByIdAsync(command.UserId, cancellationToken);

        if (user is null)
            throw new InvalidOperationException(
                "The selected user does not exist.");

        var house = await _houseRepo.GetByIdAsync(new HouseID(command.HouseId), cancellationToken);

        if (house is null)
            throw new InvalidOperationException(
                "House could not be found.");

        var tenant = house.AddTenant(new UserID(command.UserId), new Email(command.Email), new Name(command.FullName), new PhoneNumber(command.PhoneNumber));

        await _houseRepo.SaveChangesAsync(cancellationToken);

        return tenant.Id.Value;
    }
}