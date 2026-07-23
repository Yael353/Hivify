using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Feeds;

public readonly record struct AuthorID : IValue
{
    public Guid Value { get; }

    public AuthorID(Guid value)
    {
        if (value == Guid.Empty)
            throw new DomainException("Author ID cannot be empty.");

        Value = value;
    }
}