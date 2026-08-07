using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;
using Ansjon.Core.SharedKernel.ValuesObjects;

namespace Ansjon.Core.Aggregates.Houses.Tenants
{
    public class Tenant : BaseEntity<TenantID>
    {
        // medlemmens props
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        private Tenant() { }

        private Tenant(TenantID id, Name firstName, Name lastName, Email email, PhoneNumber phoneNumber) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            CreatedAt = DateTime.UtcNow;
        }

        internal static Tenant Create(TenantID id, Name firstName, Name lastName, Email email, PhoneNumber phoneNumber)
        {
            return new Tenant(id, firstName, lastName, email, phoneNumber);
        }

        internal void Delete()
        {
            if (DeletedAt != null)
                throw new DomainException("Boende är redan borttaget.");
            DeletedAt = DateTime.UtcNow;
        }
    }
}