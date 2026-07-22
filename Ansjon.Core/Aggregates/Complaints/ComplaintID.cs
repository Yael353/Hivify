using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Complaints
{
    public readonly record struct ComplaintID(Guid Value) : IValue
    {
    }
}
