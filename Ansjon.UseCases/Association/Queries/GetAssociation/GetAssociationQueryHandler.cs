using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Association.Queries.GetAssociation;

public sealed class GetAssociationQueryHandler : IQueryHandler<GetAssociationQuery, Core.Aggregates.Associations.Association?>
{
    private readonly IAssociationRepo _associationRepository;

    public GetAssociationQueryHandler(IAssociationRepo associationRepository)
    {
        _associationRepository = associationRepository;
    }

    public async Task<Core.Aggregates.Associations.Association?> Handle(GetAssociationQuery query, CancellationToken cancellationToken)
    {
        return await _associationRepository.GetByIdAsync(
            query.AssociationId,
            cancellationToken);
    }
}