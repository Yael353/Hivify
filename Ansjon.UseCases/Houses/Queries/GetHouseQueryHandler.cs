using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Houses.DTOs;

namespace Ansjon.UseCases.Houses.Queries.GetHouses;

public sealed class GetHousesQueryHandler
    : IQueryHandler<
        GetHousesQuery,
        IReadOnlyList<HouseListItemDto>>
{
    private readonly IHouseRepo _houseRepo;

    public GetHousesQueryHandler(
        IHouseRepo houseRepo)
    {
        _houseRepo = houseRepo;
    }

    public async Task<IReadOnlyList<HouseListItemDto>> Handle(
        GetHousesQuery query,
        CancellationToken cancellationToken)
    {
        var houses =
            await _houseRepo.GetAllAsync(cancellationToken);

        return houses
            .Select(house =>
                new HouseListItemDto(
                    house.Id.Value,
                    house.Address.Value,
                    house.HouseNumber.Value,
                    house.PostalCode.Value,
                    house.CreatedAt))
            .ToList();
    }
}