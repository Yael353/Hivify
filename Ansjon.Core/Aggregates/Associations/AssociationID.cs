using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Associations
{
    public readonly record struct AssociationID(Guid Value) : IValue
    {
    }
}
