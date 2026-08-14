using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;
using Ansjon.Core.SharedKernel.ValuesObjects;

namespace Ansjon.Core.Aggregates.Houses;

public class House : BaseEntity<HouseID>, IAggregateRoot
{

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
        Address address,
        HouseNumber houseNumber,
        PostalCode postalCode)
        : base(id)
    {
        Address = address;
        HouseNumber = houseNumber;
        PostalCode = postalCode;
        CreatedAt = DateTime.UtcNow;
    }


    public static House Create(
        Address address,
        HouseNumber houseNumber,
        PostalCode postalCode)
    {
        return new House(
            new HouseID(Guid.NewGuid()),
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

    public Tenant AddTenant(UserID userId)
    {
        EnsureNotDeleted();

        if (_tenants.Any(t =>
            t.UserId == userId &&
            t.DeletedAt == null))
        {
            throw new DomainException("Användaren är redan boende i detta hus.");
        }

        var tenant = Tenant.Create(
            new TenantID(Guid.NewGuid()),
            userId);

        _tenants.Add(tenant);

        return tenant;
    }

    public void RemoveTenant(TenantID tenantId)
    {
        EnsureNotDeleted();

        var tenant = _tenants.FirstOrDefault(t => t.Id == tenantId);
        if (tenant == null)
            throw new DomainException("Boende kunde inte hittas i detta hus.");

        _tenants.Remove(tenant);
    }

    public Tenant? GetTenant(TenantID tenantId)
    {
        return _tenants.FirstOrDefault(t => t.Id == tenantId);
    }


}