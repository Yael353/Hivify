using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Abstractions.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructure.Repositories.TenantRepo;

public class TenantRepo : ITenantRepo
{
    private readonly ApplicationDbContext _context;

    public TenantRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Tenant?> GetByUserIdAsync(UserID userId, CancellationToken cancellationToken = default)
    {
        return await _context.Tenants
            .FirstOrDefaultAsync(t => t.UserId == userId, cancellationToken);
    }
}