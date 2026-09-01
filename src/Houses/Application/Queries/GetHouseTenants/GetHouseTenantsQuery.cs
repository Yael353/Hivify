using Houses.Application.DTOs;
using SharedKernel.Messaging;

namespace Houses.Application.Queries.GetHouseTenants;

public sealed record GetHouseTenantsQuery(Guid HouseId) : IQuery<IReadOnlyList<TenantListItemDto>>;