using Ansjon.Core.Aggregates.Association.Feeds;

namespace Ansjon.UseCases.Communications.InterFaces
{
    public interface IFeedRepo
    {
        Task CreateFeedAsync(Feed feed);
        Task<IEnumerable<Feed>> GetAllFeedsAsync();
        Task<IEnumerable<Feed>> GetAllByDateAsync(DateTime CreatedDate);
        Task<Feed?> GetByIdAsync(Guid id);
        Task UpdateFeedAsync(Feed feed);
        Task DeleteFeedByIdAsync(Guid id);

    }

}
