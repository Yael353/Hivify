using Hivify.Core.Aggregates.Houses;
using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;
using Hivify.UseCases.Houses.DTOs;

namespace Hivify.UseCases.Houses.Queries.GetHouseTenants;

public sealed class GetHouseTenantsQueryHandler : IQueryHandler<GetHouseTenantsQuery, IReadOnlyList<TenantListItemDto>>
{
    private readonly IHouseRepo _houseRepo;

    public GetHouseTenantsQueryHandler(IHouseRepo houseRepo)
    {
        _houseRepo = houseRepo;
    }

    public async Task<IReadOnlyList<TenantListItemDto>> Handle(GetHouseTenantsQuery query, CancellationToken cancellationToken)
    {
        var house = await _houseRepo.GetByIdAsync(
            new HouseID(query.HouseId),
            cancellationToken);

        if (house is null)
            throw new InvalidOperationException(
                "House could not be found.");

        return house.Tenants
            .Where(t => t.DeletedAt == null)
            .Select(t => new TenantListItemDto(
                t.Id.Value,
                t.UserId.Value,
                t.Email.Value,
                t.FullName.Value,
                t.PhoneNumber.Value,
                t.CreatedAt))
            .ToList();
    }
}