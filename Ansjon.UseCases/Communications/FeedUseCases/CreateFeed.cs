using Ansjon.Core.Entities;
using Ansjon.UseCases.Communications.DTO;

namespace Ansjon.UseCases.Communications.FeedUseCases
{

    public class CreateFeed
    {
        private ICommunicationRepo communicationRepo;
        public CreateFeed(ICommunicationRepo _communicationRepo)
        {
            communicationRepo = _communicationRepo;
        }

        public Guid CreateFeedCommand(CreateFeedDto input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (string.IsNullOrWhiteSpace(input.Title))
            {
                throw new ArgumentException("Title is required.", nameof(input.Title));
            }

            if (input.Title.Length > 200)
            {
                throw new ArgumentException("Title cannot exceed 200 characters.", nameof(input.Title));
            }

            var feed = new Feed
            {
                Title = input.Title.Trim(),
                Content = input.Content?.Trim() ?? string.Empty
            };

            await communicationRepo.CreateFeedAsync(feed);

            return feed.Id;

        }

    }
}
