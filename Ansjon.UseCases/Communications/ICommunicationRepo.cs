using Ansjon.Core.Entities;

namespace Ansjon.UseCases.Communications
{
    public interface ICommunicationRepo
    {
        Task<IEnumerable<Feed>> GetAllFeedsAsync();

        Task<Feed?> GetByIdAsync(Guid id);

        Task<IEnumerable<Feed>> GetAllByDateAsync(DateTime CreatedDate);
    }

}
