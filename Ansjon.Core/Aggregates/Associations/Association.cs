using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;
using Ansjon.Core.SharedKernel.ValuesObjects;

namespace Ansjon.Core.Aggregates.Associations;

public class Association : BaseEntity<AssociationID>, IAggregateRoot
{
    public Name Name { get; private set; }

    private readonly List<Member> _members = [];

    public IReadOnlyCollection<Member> StaffMembers => _members.AsReadOnly();


    private Association() { }


    private Association(AssociationID id, Name name) : base(id)
    {
        Name = name;
    }


    public static Association Create(Name name)
    {
        return new Association(new AssociationID(Guid.NewGuid()), name);
    }


    public Member CreateMember(UserID userId, Name fullName, MemberRole role)
    {
        EnsureMemberDoesNotExist(userId);

        var member =
            Member.Create(
                Id,
                userId,
                fullName,
                role);

        _members.Add(member);

        return member;
    }


    private void EnsureMemberDoesNotExist(UserID userId)
    {
        if (_members.Any(member =>
            member.UserId == userId &&
            member.DeletedAt == null))
        {
            throw new DomainException(
                "Användaren är redan styrelsemedlem i denna förening.");
        }
    }
}