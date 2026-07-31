using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.Aggregates.Houses.Tenants
{
    public sealed record Name : BaseValue<string>
    {
        public Name(string value) : base(Validate(value))
        {
        }

        private static string Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Namn är obligatoriskt.");
         
            value = value.Trim();
            if (value.Length > 100)
            {
                throw new DomainException("Namn får inte vara längre än 100 tecken.");
            }
            return value;
        }
    }
}
