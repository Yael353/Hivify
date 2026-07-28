using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Houses
{
    public readonly record struct HouseID(Guid Value) : IEntity
    {
    }

}
