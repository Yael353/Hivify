using Ansjon.Core.Aggregates.Associations.Staff;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Associations;

public class AssociationEntity : BaseEntity<AssociationID>, IAggregateRoot
{
    public string Name { get; private set; }

    private readonly List<StaffMember> _members = [];

    public IReadOnlyCollection<StaffMember> StaffMembers
        => _members.AsReadOnly();


    private AssociationEntity()
    {
        // EF Core
    }


    private AssociationEntity(
        AssociationID id,
        string name)
        : base(id)
    {
        Name = name;
    }


    public static AssociationEntity Create(string name)
    {
        return new AssociationEntity(
            new AssociationID(Guid.NewGuid()),
            name);
    }


    public StaffMember CreateMember(
        string fullName,
        StaffRole role)
    {
        var member = StaffMember.Create(
            Id,
            fullName,
            role);

        _members.Add(member);

        return member;
    }
}