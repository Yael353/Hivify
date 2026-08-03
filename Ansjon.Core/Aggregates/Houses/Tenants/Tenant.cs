using Ansjon.Core.Aggregates.Houses;
using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Houses.Tenants
{
    public class Tenant : BaseEntity<TenantID>, IAggregateRoot
    {
        // medlemmens props
        public Name FirstName { get; private set; }
        public Name LastName { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }

        // Referens till hus

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

        public static Tenant Create(Name firstName, Name lastName, Email email, PhoneNumber phoneNumber, HouseID houseId)
        {
          return new Tenant(new TenantID(Guid.NewGuid()), firstName, lastName, email, phoneNumber);
        }

        public void Delete()
        {
            if (DeletedAt != null)
                throw new DomainException("Boende är redan borttaget.");
            DeletedAt = DateTime.UtcNow;
        }
    }
}