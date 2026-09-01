using Hivify.Association.Domain.Associations;

namespace Association.Application.Abstractions
{
    public interface IAssociationRepo
    {
        Task<AssociationEntity?> GetByIdAsync(AssociationID id, CancellationToken cancellationToken);
        Task<IReadOnlyList<AssociationEntity>> GetAllAsync(CancellationToken cancellationToken);


        Task AddAsync(AssociationEntity AssociationEntity, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}

