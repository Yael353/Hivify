using Hivify.Core.Houses;
using Hivify.Infrastructures.SqlDatabase;
using Hivify.UseCases.Abstractions.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Hivify.Infrastructures.Repositories.HouseRepo;

public class HouseRepo : IHouseRepo
{
    private readonly ApplicationDbContext _context;

    public HouseRepo(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<House?> GetByIdAsync(HouseID id, CancellationToken cancellationToken = default)
    {
        return await _context.Houses
            .Include(h => h.Tenants)
            .FirstOrDefaultAsync(
                h => h.Id == id,
                cancellationToken);
    }

    public async Task<IEnumerable<House>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Houses
            .OrderBy(h => h.HouseNumber.Value)
            .ToListAsync(cancellationToken);
    }

    public async Task AddAsync(House house, CancellationToken cancellationToken = default)
    {
        await _context.Houses.AddAsync(house, cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}