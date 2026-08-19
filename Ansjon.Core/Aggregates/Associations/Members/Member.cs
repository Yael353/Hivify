using Ansjon.Core.SharedKernel;
namespace Ansjon.Core.Aggregates.Associations.Members;

public class Member : BaseEntity<MemberID>
{
    public AssociationID AssociationId { get; private set; }

    public string FullName { get; private set; }

    public MemberRole Role { get; private set; }


    private Member() { }


    private Member(MemberID id, AssociationID associationId, string fullName, MemberRole role) : base(id)
    {
        AssociationId = associationId;
        FullName = fullName;
        Role = role;
    }


    public static Member Create(AssociationID associationId, string fullName, MemberRole role)
    {
        return new Member(
            new MemberID(Guid.NewGuid()),
            associationId,
            fullName,
            role);
    }
}