using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Houses.Complaints
{
    public readonly record struct ComplaintID(Guid Value) : IEntity
    {
    }
}
