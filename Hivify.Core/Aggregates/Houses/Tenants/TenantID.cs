using Hivify.Core.Exceptions;
using Hivify.Core.SharedKernel;

namespace Hivify.Core.Aggregates.Houses.Tenants;

public readonly record struct TenantID : IValue
{
    public Guid Value { get; }

    public TenantID(Guid value)
    {
        if (value == Guid.Empty)
            throw new DomainException("Tenant ID cannot be empty.");

        Value = value;
    }
}