using Ansjon.Core.Aggregates.Associations;
using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Abstractions.Context;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.ContextProviders
{

    public sealed class CurrentAssociationProvider
        : ICurrentAssociationProvider
    {
        private readonly ApplicationDbContext _dbContext;

        public CurrentAssociationProvider(
            ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<AssociationID> GetAssociationIdAsync(
            CancellationToken cancellationToken = default)
        {
            var association = await _dbContext.Associations
                .Select(x => x.Id)
                .FirstOrDefaultAsync(cancellationToken);


            if (association == default)
            {
                throw new InvalidOperationException(
                    "No association exists.");
            }


            return association;
        }
    }
}
