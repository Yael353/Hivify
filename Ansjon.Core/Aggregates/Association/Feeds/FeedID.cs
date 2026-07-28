using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Association.Feeds
{
    public readonly record struct FeedID(Guid Value) : IValue
    {
    }
}
