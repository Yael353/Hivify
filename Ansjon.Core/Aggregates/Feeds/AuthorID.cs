using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Feeds
{
    public readonly record struct AuthorID(Guid Value) : IValue
    {
    }
}
