using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Houses.DTOs;

namespace Ansjon.UseCases.Houses.Queries.GetHouseTenants;

public sealed record GetHouseTenantsQuery(
    Guid HouseId)
    : IQuery<IReadOnlyList<TenantListItemDto>>;