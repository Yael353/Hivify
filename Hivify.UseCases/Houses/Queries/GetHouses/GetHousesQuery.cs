using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Houses.DTOs;

namespace Hivify.UseCases.Houses.Queries.GetHouses;

public sealed record GetHousesQuery : IQuery<IReadOnlyList<HouseListItemDto>>;