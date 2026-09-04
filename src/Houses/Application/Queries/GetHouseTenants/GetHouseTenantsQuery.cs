using BuildingBlocks.ApplicationPorts.Messeging;
using Houses.Application.Contracts;

namespace Houses.Application.Queries.GetHouseTenants;

public sealed record GetHouseTenantsQuery(Guid HouseId) : IQuery<IReadOnlyList<TenantListItem>>;