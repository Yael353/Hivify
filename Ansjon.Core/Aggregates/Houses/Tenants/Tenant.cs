using Ansjon.Core.Aggregates.Houses.Tenants;
using Ansjon.Core.SharedKernel;
using Ansjon.Core.SharedKernel.ValuesObjects;

public class Tenant : BaseEntity<TenantID>
{
    public UserID UserId { get; private set; }
    public Email Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    private Tenant() { }

    private Tenant(TenantID id, UserID userId, Email email) : base(id)
    {
        UserId = userId;
        Email = email;
        CreatedAt = DateTime.UtcNow;
    }

    internal static Tenant Create(TenantID id, UserID userId, Email email)
    {
        return new Tenant(id, userId, email);
    }
}