using Hivify.Core.SharedKernel;

namespace Complaints.Domain
{
    public readonly record struct ComplaintID(Guid Value) : IValue
    {
    }
}
