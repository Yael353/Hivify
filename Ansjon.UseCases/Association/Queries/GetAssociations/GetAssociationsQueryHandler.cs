using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Association.Queries.GetAssociations;

public sealed class GetAssociationsQueryHandler : IQueryHandler<GetAssociationsQuery, IReadOnlyList<Core.Aggregates.Associations.Association>>
{
    private readonly IAssociationRepo _associationRepository;

    public GetAssociationsQueryHandler(IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<IReadOnlyList<Core.Aggregates.Associations.Association>> Handle(GetAssociationsQuery query, CancellationToken cancellationToken)
    {
        return await _associationRepository.GetAllAsync(cancellationToken);
    }
}