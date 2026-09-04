using Association.Domain.Associations;

namespace Association.Application.Contracts
{
    public interface IAssociationRepo
    {
        Task<AssociationEntity?> GetByIdAsync(AssociationID id, CancellationToken cancellationToken);
        Task<IReadOnlyList<AssociationEntity>> GetAllAsync(CancellationToken cancellationToken);


        Task AddAsync(AssociationEntity AssociationEntity, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}

