using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Houses.DTOs;

namespace Hivify.UseCases.Houses.Queries.GetHouse;

public sealed record GetHouseQuery(Guid HouseId) : IQuery<HouseListItemDto>;