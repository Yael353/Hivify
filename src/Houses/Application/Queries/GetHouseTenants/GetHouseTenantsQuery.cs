using Houses.Application.Contracts;
using SharedKernel.Messaging;

namespace Houses.Application.Queries.GetHouseTenants;

public sealed record GetHouseTenantsQuery(Guid HouseId) : IQuery<IReadOnlyList<TenantListItem>>;