using Ansjon.Core.Interfaces;

namespace Ansjon.Core.Common
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; protected set; }

    }
}
