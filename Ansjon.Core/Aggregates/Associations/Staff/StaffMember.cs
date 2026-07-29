using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Associations.Staff;
using Ansjon.Core.SharedKernel;

public class StaffMember : BaseEntity<StaffMemberID>
{
    public AssociationID AssociationId { get; private set; }

    public string FullName { get; private set; }

    public StaffRole Role { get; private set; }


    private StaffMember()
    {
    }


    private StaffMember(
        StaffMemberID id,
        AssociationID associationId,
        string fullName,
        StaffRole role)
        : base(id)
    {
        AssociationId = associationId;
        FullName = fullName;
        Role = role;
    }


    public static StaffMember Create(
        AssociationID associationId,
        string fullName,
        StaffRole role)
    {
        return new StaffMember(
            new StaffMemberID(Guid.NewGuid()),
            associationId,
            fullName,
            role);
    }
}