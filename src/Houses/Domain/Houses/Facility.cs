using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Houses
{
    public sealed record Facility : BaseValue<string>
    {
        public Facility(string value) : base(value)
        {
        }

    }
}
