using Hivify.Core.SharedKernel;

namespace Hivify.Core.Aggregates.Associations
{
    public readonly record struct AssociationID(Guid Value) : IValue
    {
    }
}
