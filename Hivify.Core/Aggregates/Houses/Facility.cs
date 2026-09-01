using Hivify.Core.SharedKernel;

namespace Hivify.Core.Aggregates.Houses
{
    public sealed record Facility : BaseValue<string>
    {
        public Facility(string value) : base(value)
        {
        }

    }
}
