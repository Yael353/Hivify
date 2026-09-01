using Houses.Application.DTOs;
using SharedKernel.Messaging;

namespace Houses.Application.Queries.GetHouses;

public sealed record GetHousesQuery : IQuery<IReadOnlyList<HouseListItemDto>>;