using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Houses.Complaints;

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