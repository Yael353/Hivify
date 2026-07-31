using Ansjon.Core.Aggregates.Houses;
using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Houses.Tenants
{
    public class Tenant : BaseEntity<TenantID>, IAggregateRoot
    {
        // medlemmens props
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        // Referens till hus
        public HouseID HouseId { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        private Tenant() { }

        private Tenant(TenantID id, string name, string email, string phoneNumber, HouseID houseId) : base(id)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            HouseId = houseId;
            CreatedAt = DateTime.UtcNow;
        }

        public static Tenant Create(string name, string email, string phoneNumber, HouseID houseId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Namn är obligatoriskt.");
            if (string.IsNullOrWhiteSpace(email))
                throw new DomainException("Email är obligatoriskt.");
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new DomainException("Telefonnummer är obligatoriskt.");
            if (houseId == null)
                throw new DomainException("House ID är obligatoriskt.");

            return new Tenant(new TenantID(Guid.NewGuid()), name, email, phoneNumber, houseId);
        }

        public void MoveToHouse(HouseID newHouseId)
        {
            if (DeletedAt != null)
                throw new DomainException("Borttagen boende kan inte flyttas.");
            if (newHouseId == null)
                throw new DomainException("Nytt hus-ID är obligatoriskt.");

            HouseId = newHouseId;
        }

        public void Delete()
        {
            if (DeletedAt != null)
                throw new DomainException("Boende är redan borttaget.");
            DeletedAt = DateTime.UtcNow;
        }
    }
}