using BuildingBlocks.ApplicationPorts.Messeging;
using Houses.Application.Contracts;

namespace Houses.Application.Queries.GetHouses;

public sealed record GetHousesQuery : IQuery<IReadOnlyList<HouseListItem>>;