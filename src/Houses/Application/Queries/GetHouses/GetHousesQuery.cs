using Houses.Application.Contracts;
using SharedKernel.Messaging;

namespace Houses.Application.Queries.GetHouses;

public sealed record GetHousesQuery : IQuery<IReadOnlyList<HouseListItem>>;