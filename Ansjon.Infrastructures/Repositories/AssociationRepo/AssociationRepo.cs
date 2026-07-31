using Ansjon.Core.Aggregates.Associations;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Abstractions.Presistence;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Repositories.AssociationRepo
{
    public sealed class AssociationRepository : IAssociationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AssociationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<Association?> GetByIdAsync(
            AssociationID id,
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Associations
                .FirstOrDefaultAsync(
                    a => a.Id == id,
                    cancellationToken);
        }

        public async Task AddAsync(
            Association association,
            CancellationToken cancellationToken = default)
        {
            await _dbContext.Associations.AddAsync(association, cancellationToken);
        }

        public async Task SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

}