using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Associations.Members
{
    public readonly record struct MemberID(Guid Value) : IValue
    {
    }
}
