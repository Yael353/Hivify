using Hivify.Core.Aggregates.Associations;

namespace Hivify.UseCases.Abstractions.Presistence
{
    public interface IAssociationRepo
    {
        Task<Core.Aggregates.Associations.Association?> GetByIdAsync(AssociationID id, CancellationToken cancellationToken);
        Task<IReadOnlyList<Core.Aggregates.Associations.Association>> GetAllAsync(CancellationToken cancellationToken);


        Task AddAsync(Core.Aggregates.Associations.Association association, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}

