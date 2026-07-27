using Ansjon.Core.Exceptions;
using Ansjon.Core.SharedKernel;

namespace Ansjon.Core.AppValues
{
    public sealed record Title : ValueObject<string>
    {
        public Title(string value)
      : base(Validate(value))
        {
        }

        private static string Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Title is required.");

            value = value.Trim();

            if (value.Length > 200)
                throw new DomainException("Title cannot exceed 200 characters.");

            return value;
        }


    }
}
