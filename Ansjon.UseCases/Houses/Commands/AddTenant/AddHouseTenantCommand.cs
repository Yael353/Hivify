using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Houses.Commands.AddTenant;

public sealed record AddHouseTenantCommand(Guid HouseId, Guid UserId, string Email, string FullName, string PhoneNumber) : ICommand<Guid>;