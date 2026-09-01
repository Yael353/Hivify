using Hivify.Association.Domain.Associations;

namespace Hivify.UseCases.Abstractions.Presistence
{
    public interface IAssociationRepo
    {
        Task<Hivify.AssociationEntity.Domain.Associations.AssociationEntity?> GetByIdAsync(AssociationID id, CancellationToken cancellationToken);
        Task<IReadOnlyList<Hivify.AssociationEntity.Domain.Associations.AssociationEntity>> GetAllAsync(CancellationToken cancellationToken);


        Task AddAsync(Hivify.AssociationEntity.Domain.Associations.AssociationEntity AssociationEntity, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}




