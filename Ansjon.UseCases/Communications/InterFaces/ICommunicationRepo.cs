using Ansjon.Core.Entities;

namespace Ansjon.UseCases.Communications.InterFaces
{
    public interface ICommunicationRepo
    {
        Task CreateFeedAsync(Feed feed);
        Task<IEnumerable<Feed>> GetAllFeedsAsync();
        Task<IEnumerable<Feed>> GetAllByDateAsync(DateTime CreatedDate);
        Task<Feed?> GetByIdAsync(Guid id);
        Task UpdateFeedAsync(Feed feed);
        Task DeleteFeedByIdAsync(Guid id);

    }

}
