using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Association
{
    public class StaffMember : BaseEntity<StaffMemberID>, IAggregateRoot
    {

        public string FullName { get; private set; }
        public StaffRole Role { get; private set; }


        private StaffMember() { }
        private StaffMember(string fullName, StaffRole role)
        {
            FullName = fullName;
            Role = role;
        }

        public static StaffMember Create(string fullName, StaffRole role)
        {
            return new StaffMember(fullName, role);
        }
    }
}
