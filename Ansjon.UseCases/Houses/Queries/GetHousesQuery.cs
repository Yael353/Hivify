using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Houses.DTOs;

namespace Ansjon.UseCases.Houses.Queries.GetHouses;

public sealed record GetHousesQuery
    : IQuery<IReadOnlyList<HouseListItemDto>>;