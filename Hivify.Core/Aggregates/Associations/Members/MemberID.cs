using Hivify.Core.SharedKernel;

namespace Hivify.Core.Aggregates.Associations.Members
{
    public readonly record struct MemberID(Guid Value) : IValue
    {
    }
}
