using Ansjon.Core.SharedKernel;
using Ansjon.Core.SharedKernel.ValuesObjects;
namespace Ansjon.Core.Aggregates.Associations.Members;

public class Member : BaseEntity<MemberID>
{
    public AssociationID AssociationId { get; private set; }
    public UserID UserId { get; private set; }

    public Name FullName { get; private set; }

    public MemberRole Role { get; private set; }

    public DateTime? DeletedAt { get; private set; }


    private Member() { }


    private Member(MemberID id, AssociationID associationId, UserID userId, Name fullName, MemberRole role) : base(id)
    {
        AssociationId = associationId;
        UserId = userId;
        FullName = fullName;
        Role = role;
    }


    public static Member Create(AssociationID associationId, UserID userId, Name fullName, MemberRole role)
    {
        return new Member(
            new MemberID(Guid.NewGuid()),
            associationId,
            userId,
            fullName,
            role);
    }
}