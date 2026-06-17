using Ansjon.Core.Entities;

namespace Ansjon.UseCases.Communications.FeedUseCases
{
    public class UpdateFeed
    {
        private readonly ICommunicationRepo _communicationRepo;

        public UpdateFeed(ICommunicationRepo communicationRepo)
        {
            _communicationRepo = communicationRepo;
        }

        public async Task UpdateFeedAsync(Feed input)
        {
            var existing = await _communicationRepo.GetByIdAsync(input.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Feed with ID {input.Id} not found.");
            }
            existing.Title = input.Title?.Trim() ?? existing.Title;
            existing.Content = input.Content?.Trim() ?? existing.Content;

            await _communicationRepo.UpdateFeedAsync(existing);
        }
    }
}
