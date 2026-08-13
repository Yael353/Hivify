using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Houses.Commands.RemoveTenant;

public sealed record RemoveHouseTenantCommand(
    Guid HouseId,
    Guid TenantId)
    : ICommand<bool>;