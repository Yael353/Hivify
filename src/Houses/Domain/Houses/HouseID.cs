using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Houses
{
    public readonly record struct HouseID : IValue
    {
        public Guid Value { get; }

        public HouseID(Guid value)
        {
            if (value == Guid.Empty)
                throw new DomainException("House ID cannot be empty.");

            Value = value;
        }
    }

}
