using Hivify.Core.Exceptions;
using SharedKernel;

namespace SharedKernel.ValuesObjects
{
    public sealed record Name : BaseValue<string>
    {
        public Name(string value) : base(Validate(value))
        {
        }

        internal static string Validate(string value)
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
