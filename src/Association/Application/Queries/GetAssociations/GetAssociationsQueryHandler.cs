using Association.Application.Abstractions;
using Association.Application.DTOs;
using SharedKernel.Messaging;

namespace Hivify.Association.Application.Queries.GetAssociations;

public sealed class GetAssociationsQueryHandler
    : IQueryHandler<
        GetAssociationsQuery,
        IReadOnlyList<AssociationListDto>>
{
    private readonly IAssociationRepo _associationRepository;

    public GetAssociationsQueryHandler(
        IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<IReadOnlyList<AssociationListDto>> Handle(
        GetAssociationsQuery query,
        CancellationToken cancellationToken)
    {
        var associations =
            await _associationRepository.GetAllAsync(
                cancellationToken);

        return associations
            .Select(AssociationEntity =>
                new AssociationListDto
                {
                    Id = AssociationEntity.Id.Value,
                    Name = AssociationEntity.Name.Value
                })
            .ToList();
    }
}



