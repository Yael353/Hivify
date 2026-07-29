using Ansjon.Core.Aggregates.Associations;

namespace Ansjon.UseCases.Abstractions.Presistence;

public interface IAssociationRepository
{
    Task<AssociationEntity?> GetByIdAsync(
        AssociationID id,
        CancellationToken cancellationToken);

    Task AddAsync(
        AssociationEntity association,
        CancellationToken cancellationToken);

    Task SaveChangesAsync(
        CancellationToken cancellationToken);
}