using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Feeds
{
    public readonly record struct ComplaintID(Guid Value) : IValue
    {
    }
}
