using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Houses.Commands.AddTenant;

public sealed record AddHouseTenantCommand(Guid HouseId, Guid UserId, string Email, string FullName, string PhoneNumber) : ICommand<Guid>;