using Ansjon.Core.Entities;


namespace Ansjon.UseCases.Communications.FeedUseCases
{
    public class ViewFeeds
    {
        //GetAllFeeds
        // A feed can be a post, an article, etc. has a title, post-date(CreatedAt) and a discription.It will be created by the system.  It will only be displayed in a feedcomponent for the users.
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
