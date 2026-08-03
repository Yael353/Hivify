using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Houses;

public class House : BaseEntity<HouseID>, IAggregateRoot
{
    public AssociationID AssociationId { get; private set; }
    public Address Address { get; private set; }
    public HouseNumber HouseNumber { get; private set; }
    public PostalCode PostalCode { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    private readonly List<Tenant> _tenants = [];

    public IReadOnlyCollection<Tenant> Tenants
    => _tenants.AsReadOnly();


    private House()
    {
    }


    private House(
        HouseID id,
        AssociationID associationId,
        Address address,
        HouseNumber houseNumber,
        PostalCode postalCode)
        : base(id)
    {
        AssociationId = associationId;
        Address = address;
        HouseNumber = houseNumber;
        PostalCode = postalCode;
        CreatedAt = DateTime.UtcNow;
    }


    public static House Create(
        AssociationID associationId,
        Address address,
        HouseNumber houseNumber,
        PostalCode postalCode)
    {
        return new House(
            new HouseID(Guid.NewGuid()),
            associationId,
            address,
            houseNumber,
            postalCode);
    }


    public void Update(
        Address address,
        HouseNumber houseNumber,
        PostalCode postalCode)
    {
        EnsureNotDeleted();

        Address = address;
        HouseNumber = houseNumber;
        PostalCode = postalCode;
    }


    public void Delete()
    {
        EnsureNotDeleted();
        DeletedAt = DateTime.UtcNow;
    }


    private void EnsureNotDeleted()
    {
        if (DeletedAt != null)
            throw new DomainException(
                "The house has been deleted.");
    }

    public Tenant AddTenant(
       Name firstName,
       Name lastName,
       Email email,
       PhoneNumber phoneNumber)
    {
        EnsureNotDeleted();

        var tenant = Tenant.Create(
            new TenantID(Guid.NewGuid()),
            firstName,
            lastName,
            email,
            phoneNumber);

        _tenants.Add(tenant);

        return tenant;
    }


}