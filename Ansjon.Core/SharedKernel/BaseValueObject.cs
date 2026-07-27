namespace Ansjon.Core.SharedKernel
{
    public abstract record ValueObject<T>(T Value) : IValue
    {
        public override string ToString() => Value?.ToString() ?? string.Empty;
    }
}
