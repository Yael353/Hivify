using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Association

{
    public class Association : BaseEntity<AssociationID>, IAggregateRoot
    {

        public string Name { get; private set; }
        public List<StaffMember> StaffMembers { get; private set; } = new List<StaffMember>();



        private Association() { }

        private Association(AssociationID id, string name) : base(id)
        {
            Name = name;
        }

        public static Association Create(AssociationID id, string name)
        {
            return new Association(id, name);
        }

        public void AddStaffMember(StaffMember member)
        {
            StaffMembers.Add(member);
        }
    }
}
