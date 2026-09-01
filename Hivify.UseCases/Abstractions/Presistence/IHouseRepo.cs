using Hivify.Core.Aggregates.Houses;


namespace Hivify.UseCases.Abstractions.Presistence
{
    public interface IHouseRepo
    {
        Task<House?> GetByIdAsync(HouseID id, CancellationToken cancellationToken = default);
        Task<IEnumerable<House>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(House house, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
