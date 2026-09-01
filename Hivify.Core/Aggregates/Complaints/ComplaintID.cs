using Hivify.Core.SharedKernel;

namespace Hivify.Core.Aggregates.Complaints
{
    public readonly record struct ComplaintID(Guid Value) : IValue
    {
    }
}
