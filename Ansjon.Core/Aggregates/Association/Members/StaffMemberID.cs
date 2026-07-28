using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Association.Members
{
    public readonly record struct StaffMemberID(Guid Value) : IEntity
    {
    }
}
