using Association.Application.DTOs;
using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;

namespace Association.Application.Queries.GetAssociations;

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
            .Select(association =>
                new AssociationListDto
                {
                    Id = association.Id.Value,
                    Name = association.Name.Value
                })
            .ToList();
    }
}