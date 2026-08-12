using Ansjon.Core.Aggregates.Houses;
using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Houses.Commands.AddTenant;

public sealed record AddHouseTenantCommand(
    HouseID HouseId,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
) : ICommand<Guid>;