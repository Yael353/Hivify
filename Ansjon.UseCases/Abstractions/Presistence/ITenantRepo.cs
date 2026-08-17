using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Core.SharedKernel.ValuesObjects;

namespace Ansjon.UseCases.Abstractions.Presistence;

public interface ITenantRepo
{
    Task<Tenant?> GetByUserIdAsync(UserID userId, CancellationToken cancellationToken = default);
}