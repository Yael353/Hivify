using System;
using System.Collections.Generic;
using System.Text;

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
            var existing = await _communicationRepo.GetByIdAsync(feedId);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Feed with ID {feedId} not found.");
            }

            await _communicationRepo.DeleteFeedAsync(existing);
        }
    }
}
