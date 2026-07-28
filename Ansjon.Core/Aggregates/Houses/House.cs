using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Houses;

public class House : BaseEntity<HouseID>, IAggregateRoot
{
    public Address Address { get; private set; }
    public HouseNumber HouseNumber { get; private set; }
    public PostalCode PostalCode { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    private House()
    {
        // Required by EF Core
    }

    private House(
        HouseID id,
        Address address,
        HouseNumber houseNumber,
        PostalCode postalCode
        )
        : base(id)
    {
        Address = address;
        HouseNumber = houseNumber;
        PostalCode = postalCode;

    }

    public static House Create(
        Address address,
        HouseNumber houseNumber,
        PostalCode postalCode,

        int yearBuilt,
        int numberOfRooms,
        decimal livingArea,
        decimal? plotArea)
    {
        return new House(
            new HouseID(Guid.NewGuid()),
            address,
            houseNumber,
            postalCode
            );
    }

    public void Update(
        Address address,
        HouseNumber houseNumber,
        PostalCode postalCode,

        int yearBuilt,
        int numberOfRooms,
        decimal livingArea,
        decimal? plotArea)
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
            throw new DomainException("House has been deleted.");
    }
}