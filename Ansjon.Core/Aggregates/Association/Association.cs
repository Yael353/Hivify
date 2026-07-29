using Ansjon.Core.Aggregates.Association.Staff;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Association;

public class Association : BaseEntity<AssociationID>, IAggregateRoot
{
    public string Name { get; private set; }

    private readonly List<StaffMember> _members = [];

    public IReadOnlyCollection<StaffMember> StaffMembers => _members.AsReadOnly();

    private Association()
    {
        // For EF Core
    }

    private Association(AssociationID id, string name)
        : base(id)
    {
        Name = name;
    }

    public static Association Create(string name)
    {
        return new Association(
            new AssociationID(Guid.NewGuid()),
            name);
    }

    public StaffMember CreateMember(string fullName, StaffRole role)
    {
        var member = StaffMember.Create(fullName, role);

        _members.Add(member);

        return member;
    }

    public IReadOnlyCollection<StaffMember> GetMembers()
    {
        return _members.AsReadOnly();
    }
}