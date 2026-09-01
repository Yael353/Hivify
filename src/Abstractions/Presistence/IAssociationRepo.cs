using Hivify.Core.Associations.Domain;

namespace Hivify.UseCases.Abstractions.Presistence
{
    public interface IAssociationRepo
    {
        Task<Core.Associations.Domain.Association?> GetByIdAsync(AssociationID id, CancellationToken cancellationToken);
        Task<IReadOnlyList<Core.Associations.Domain.Association>> GetAllAsync(CancellationToken cancellationToken);


        Task AddAsync(Core.Associations.Domain.Association association, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}

