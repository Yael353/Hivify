using Ansjon.Core.Aggregates.Associations.Staff;
using Ansjon.Core.SharedKernel;

public class StaffMember : BaseEntity<StaffMemberID>
{
    public string FullName { get; private set; }
    public StaffRole Role { get; private set; }

    private StaffMember()
    {
    }

    private StaffMember(StaffMemberID id, string fullName, StaffRole role)
        : base(id)
    {
        FullName = fullName;
        Role = role;
    }

    internal static StaffMember Create(string fullName, StaffRole role)
    {
        return new StaffMember(
            new StaffMemberID(Guid.NewGuid()),
            fullName,
            role);
    }
}