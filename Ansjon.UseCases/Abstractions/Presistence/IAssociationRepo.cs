using Ansjon.Core.Aggregates.Associations;



namespace Ansjon.UseCases.Abstractions.Presistence
{
    public interface IAssociationRepo
    {
        Task<Core.Aggregates.Associations.Association?> GetByIdAsync(AssociationID id, CancellationToken cancellationToken);

        Task AddAsync(Core.Aggregates.Associations.Association association, CancellationToken cancellationToken);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}

