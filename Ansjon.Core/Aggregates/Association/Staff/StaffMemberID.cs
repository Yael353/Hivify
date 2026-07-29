using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Association.Staff
{
    public readonly record struct StaffMemberID(Guid Value) : IValue
    {
    }
}
