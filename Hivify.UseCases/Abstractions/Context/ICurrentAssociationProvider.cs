using Hivify.Core.Aggregates.Associations;

namespace Hivify.UseCases.Abstractions.Context
{
    public interface ICurrentAssociationProvider
    {
        Task<AssociationID> GetAssociationIdAsync(CancellationToken cancellationToken = default);
    }
}
