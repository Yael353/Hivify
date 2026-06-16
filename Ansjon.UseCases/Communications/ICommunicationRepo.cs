using Ansjon.Core.Entities;

namespace Ansjon.UseCases.Communications
{
    public interface ICommunicationRepo
    {
        Task<Guid> CreateFeedAsync(Feed feed);
        Task<IEnumerable<Feed>> GetAllFeedsAsync();
        Task <IEnumerable<Feed>> GetAllByDateAsync(DateTime CreatedDate);
        Task<Feed?> GetByIdAsync(Guid id);
        Task DeleteFeedAsync(Feed feed);
        Task UpdateFeedAsync(Feed feed);
        Task DeleteFeedByIdAsync(Guid id);

    }

}
