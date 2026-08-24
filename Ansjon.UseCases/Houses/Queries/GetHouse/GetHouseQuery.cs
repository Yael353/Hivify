using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Houses.DTOs;

namespace Ansjon.UseCases.Houses.Queries.GetHouse;

public sealed record GetHouseQuery(Guid HouseId) : IQuery<HouseListItemDto>;