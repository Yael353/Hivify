using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.Core.SharedKernel;


namespace Ansjon.Core.Aggregates.Associations;

public class Association : BaseEntity<AssociationID>, IAggregateRoot
{
    public string Name { get; private set; }

    private readonly List<Member> _members = [];

    public IReadOnlyCollection<Member> StaffMembers => _members.AsReadOnly();


    private Association() { }


    private Association(AssociationID id, string name) : base(id)
    {
        Name = name;
    }


    public static Association Create(string name)
    {
        return new Association(new AssociationID(Guid.NewGuid()), name);
    }


    public Member CreateMember(string fullName, MemberRole role)
    {
        var member = Member.Create(Id, fullName, role);

        _members.Add(member);

        return member;
    }
}
