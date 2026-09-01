using Houses.Application.DTOs;
using SharedKernel.Messaging;

namespace Houses.Application.Queries.GetHouse;

public sealed record GetHouseQuery(Guid HouseId) : IQuery<HouseListItemDto>;