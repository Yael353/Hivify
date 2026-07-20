namespace Ansjon.Core.SharedKernel
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; protected set; }

    }
}
