using Ansjon.UseCases.Communications.interfaes;

namespace Ansjon.UseCases.Communications.FeedUseCases
{
    public class DeleteFeed
    {
        private readonly ICommunicationRepo _communicationRepo;
        public DeleteFeed(ICommunicationRepo communicationRepo)
        {
            _communicationRepo = communicationRepo;
        }

        public async Task DeleteFeedAsync(Guid feedId)
        {
            await _communicationRepo.DeleteFeedByIdAsync(feedId);
        }
    }
}
