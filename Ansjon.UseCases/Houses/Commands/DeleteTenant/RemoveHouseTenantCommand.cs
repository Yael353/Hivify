using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Houses.Commands.DeleteTenant;

public sealed record RemoveHouseTenantCommand(
    Guid HouseId,
    Guid TenantId)
    : ICommand<bool>;