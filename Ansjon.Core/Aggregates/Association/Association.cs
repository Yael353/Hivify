using Ansjon.Core.Aggregates.Association;
using Ansjon.Core.Aggregates.Houses;
using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;

public class Association : BaseEntity<AssociationID>, IAggregateRoot
{
    public string Name { get; private set; }

    private readonly List<House> _houses = new();
    public IReadOnlyCollection<House> Houses => _houses.AsReadOnly();

    private readonly List<StaffMember> _staffMembers = new();
    public IReadOnlyCollection<StaffMember> StaffMembers => _staffMembers.AsReadOnly();

    private Association()
    {
    }

    private Association(
        AssociationID id,
        string name)
        : base(id)
    {
        Name = name;
    }

    public static Association Create(
        string name)
    {
        return new Association(
            new AssociationID(Guid.NewGuid()),
            name);
    }

    public void AddHouse(House house)
    {
        if (_houses.Any(h => h.Id == house.Id))
            throw new DomainException("House already belongs to this association.");

        _houses.Add(house);
    }

    public void RemoveHouse(HouseID houseId)
    {
        var house = _houses.FirstOrDefault(h => h.Id == houseId);

        if (house is null)
            throw new DomainException("House not found.");

        _houses.Remove(house);
    }

    public void AddStaffMember(StaffMember member)
    {
        _staffMembers.Add(member);
    }
}