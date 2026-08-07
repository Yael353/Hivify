using Ansjon.Core.Aggregates.Houses;
using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Houses.Commands;

public sealed record AddHouseTenantCommand(
    HouseID HouseId,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber
) : ICommand<TenantID>;