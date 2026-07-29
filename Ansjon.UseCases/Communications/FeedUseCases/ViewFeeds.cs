using Ansjon.Core.Aggregates.Feeds;
using Ansjon.UseCases.Communications.InterFaces;


namespace Ansjon.UseCases.Communications.FeedUseCases
{
    public class ViewFeeds
    {
        private readonly IFeedRepo _communicationRepo;

        public ViewFeeds(IFeedRepo communicationRepo)
        {
            _communicationRepo = communicationRepo;
        }

        public async Task<IEnumerable<Feed>> GetAllFeedsAsync()
        {
            var feed = await _communicationRepo.GetAllFeedsAsync();
            return feed.OrderByDescending(f => f.CreatedDate);
        }

        public async Task<IEnumerable<Feed>> GetFeedsByDateAsync(DateTime date)
        {
            var feed = await _communicationRepo.GetAllByDateAsync(date);
            return feed.OrderByDescending(f => f.CreatedDate);
        }

    }
}
