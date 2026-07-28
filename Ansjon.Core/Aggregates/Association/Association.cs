using Ansjon.Core.Aggregates.Association;
using Ansjon.Core.Aggregates.Association.Members;
using Ansjon.Core.SharedKernel;

public class Association : BaseEntity<AssociationID>, IAggregateRoot
{
    public string Name { get; private set; }
    private List<StaffMember> Members { get; set; } = new List<StaffMember>();



    private Association() // For EF Core
    {
    }


    private Association(AssociationID id, string name) : base(id)
    {
        Name = name;
    }


    public static Association Create(string name)
    {
        return new Association(new AssociationID(Guid.NewGuid()), name);
    }

    public static StaffMember CreateMember(string fullName, StaffRole role)
    {

        return StaffMember.Create(fullName, role);

    }

    public IReadOnlyCollection<StaffMember> GetMembers()
    {
        return Members.AsReadOnly();
    }
}