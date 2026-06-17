using Ansjon.Core.Entities;


namespace Ansjon.UseCases.Communications.FeedUseCases
{
    public class ViewFeeds
    {
        private readonly ICommunicationRepo _communicationRepo;

        public ViewFeeds(ICommunicationRepo communicationRepo)
        {
            _communicationRepo = communicationRepo;
        }

        public async Task<IEnumerable<Feed>> GetAllFeedsAsync()
        {
            return await _communicationRepo.GetAllFeedsAsync();
        }

        public async Task<IEnumerable<Feed>> GetFeedsByDateAsync(DateTime date)
        {
            return await _communicationRepo.GetAllByDateAsync(date);
        }

    }
}
