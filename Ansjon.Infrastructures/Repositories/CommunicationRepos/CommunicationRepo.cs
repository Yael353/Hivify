using Ansjon.Core.Entities;
using Ansjon.UseCases.Communications;

namespace Ansjon.Infrastructures.Repositories.CommunicationRepos
{
    public class CommunicationRepo : ICommunicationRepo
    {
        // db injection
        public Task CreateFeedAsync(Feed FeedRecord)
        {

        }
        public Task<IEnumerable<Feed>> GetAllFeedsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
