using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Association
{
    public readonly record struct StaffMemberID(Guid Value) : IEntity
    {
    }
}
