using Association.Application.Contracts;
using BuildingBlocks.ApplicationPorts.Messeging;

namespace Association.Application.Queries.GetAssociations;

public sealed class GetAssociationsQueryHandler
    : IQueryHandler<
        GetAssociationsQuery,
        IReadOnlyList<AssociationListItem>>
{
    private readonly IAssociationRepo _associationRepository;

    public GetAssociationsQueryHandler(
        IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<IReadOnlyList<AssociationListItem>> Handle(
        GetAssociationsQuery query,
        CancellationToken cancellationToken)
    {
        var associations =
            await _associationRepository.GetAllAsync(
                cancellationToken);

        return associations
            .Select(AssociationEntity =>
                new AssociationListItem
                {
                    Id = AssociationEntity.Id.Value,
                    Name = AssociationEntity.Name.Value
                })
            .ToList();
    }
}



