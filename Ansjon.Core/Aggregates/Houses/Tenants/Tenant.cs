using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Core.SharedKernel;
using Ansjon.Core.SharedKernel.ValuesObjects;

public class Tenant : BaseEntity<TenantID>
{
    public UserID UserId { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    private Tenant() { }

    private Tenant(
        TenantID id,
        UserID userId)
        : base(id)
    {
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }

    internal static Tenant Create(
        TenantID id,
        UserID userId)
    {
        return new Tenant(id, userId);
    }
}