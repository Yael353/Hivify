using Hivify.Core.SharedKernel;

namespace Hivify.Core.Aggregates.Feeds
{
    public readonly record struct FeedID(Guid Value) : IValue
    {
    }
}
