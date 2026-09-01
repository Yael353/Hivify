using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Houses.Commands.DeleteTenant;

public sealed record RemoveHouseTenantCommand(
    Guid HouseId,
    Guid TenantId)
    : ICommand<bool>;