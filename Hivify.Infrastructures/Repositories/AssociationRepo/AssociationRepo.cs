using Hivify.Core.Aggregates.Associations;
using Hivify.Infrastructures.SqlDatabase;
using Hivify.UseCases.Abstractions.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Hivify.Infrastructures.Repositories.AssociationRepo;

public sealed class AssociationRepo : IAssociationRepo
{
    private readonly ApplicationDbContext _dbContext;

    public AssociationRepo(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Association?> GetByIdAsync(
        AssociationID associationId,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Associations
            .Include(a => a.StaffMembers)
            .FirstOrDefaultAsync(
                a => a.Id == associationId,
                cancellationToken);
    }

    public async Task<IReadOnlyList<Association>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        return await _dbContext.Associations
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(
        Association association,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Associations.AddAsync(
            association,
            cancellationToken);
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}