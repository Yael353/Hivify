using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Association
{
    public readonly record struct AssociationID(Guid Value) : IEntity
    {
    }
}
