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

        public static Tenant Create(string firstName, string lastName, string email, string phoneNumber, HouseID houseId)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException("Förnamn är obligatoriskt.");
            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException("Efternamn är obligatoriskt.");
            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("Email är obligatoriskt.");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new DomainException("Telefonnummer är obligatoriskt.");
            if (houseId == null)
                throw new DomainException("House ID är obligatoriskt.");

            return new Tenant(new TenantID(Guid.NewGuid()), new Name(firstName), new Name(lastName), new Email(email), new PhoneNumber(phoneNumber));
        }

        public void Delete()
        {
            if (DeletedAt != null)
                throw new DomainException("Boende är redan borttaget.");
            DeletedAt = DateTime.UtcNow;
        }
    }
}