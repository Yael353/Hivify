
using Ansjon.UseCases.Communications.InterFaces;

namespace Ansjon.UseCases.Communications.FeedUseCases
{
    public class DeleteFeed
    {
        private readonly IFeedRepo _communicationRepo;
        public DeleteFeed(IFeedRepo communicationRepo)
        {
            _communicationRepo = communicationRepo;
        }

        public async Task DeleteFeedAsync(Guid feedId)
        {
            await _communicationRepo.DeleteFeedByIdAsync(feedId);
        }
    }
}
