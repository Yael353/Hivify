using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Houses.DTOs;

namespace Hivify.UseCases.Houses.Queries.GetHouseTenants;

public sealed record GetHouseTenantsQuery(Guid HouseId) : IQuery<IReadOnlyList<TenantListItemDto>>;