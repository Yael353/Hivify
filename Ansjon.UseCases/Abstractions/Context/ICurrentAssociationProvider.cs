using Ansjon.Core.Aggregates.Associations;

namespace Ansjon.UseCases.Abstractions.Context
{
    public interface ICurrentAssociationProvider
    {
        Task<AssociationID> GetAssociationIdAsync(
            CancellationToken cancellationToken = default);
    }
}
