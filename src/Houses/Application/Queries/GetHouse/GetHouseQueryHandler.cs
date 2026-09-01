using Hivify.UseCases.Abstractions.Presistence;
using Houses.Application.DTOs;
using Houses.Domain.Houses;
using SharedKernel.Messaging;

namespace Houses.Application.Queries.GetHouse;

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