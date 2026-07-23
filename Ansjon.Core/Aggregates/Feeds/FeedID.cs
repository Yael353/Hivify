using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Feeds
{
    public readonly record struct FeedID(Guid Value) : IValue
    {
    }
}
