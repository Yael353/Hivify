using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Associations.Staff
{
    public readonly record struct StaffMemberID(Guid Value) : IValue
    {
    }
}
