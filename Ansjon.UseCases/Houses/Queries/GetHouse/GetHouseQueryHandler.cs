using Ansjon.Core.Aggregates.Houses;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Houses.DTOs;

namespace Ansjon.UseCases.Houses.Queries.GetHouse;

public sealed class GetHouseQueryHandler
    : IQueryHandler<GetHouseQuery, HouseListItemDto>
{
    private readonly IHouseRepo _houseRepo;

    public GetHouseQueryHandler(
        IHouseRepo houseRepo)
    {
        _houseRepo = houseRepo;
    }

    public async Task<HouseListItemDto> Handle(
        GetHouseQuery query,
        CancellationToken cancellationToken)
    {
        var house = await _houseRepo.GetByIdAsync(
            new HouseID(query.HouseId),
            cancellationToken);

        if (house is null)
        {
            throw new InvalidOperationException(
                "House could not be found.");
        }

        return new HouseListItemDto(
            house.Id.Value,
            house.Address.Value,
            house.HouseNumber.Value,
            house.PostalCode.Value,
            house.CreatedAt);
    }
}