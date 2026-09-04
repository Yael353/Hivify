using BuildingBlocks.ApplicationPorts.Messeging;
using Houses.Application.Contracts;

namespace Houses.Application.Queries.GetHouse;

public sealed record GetHouseQuery(Guid HouseId) : IQuery<HouseListItem>;