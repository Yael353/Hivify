using Ansjon.Core.Entities;
using Ansjon.UseCases.Communications.DTO;
using System.Diagnostics;

namespace Ansjon.UseCases.Communications.FeedUseCases
{

    public class CreateFeed
    {
        private readonly ICommunicationRepo _communicationRepo;
        public CreateFeed(ICommunicationRepo communicationRepo)
        {
            _communicationRepo = communicationRepo;
        }

        public async Task<Guid> CreateFeedAsync(CreateFeedDto input)
        {
            ArgumentNullException.ThrowIfNull(input);

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
                Content = input.Content,
            };

            Console.WriteLine($"🔄 Use Case: Spara feed med titel: {input.Title}");

            await _communicationRepo.CreateFeedAsync(feed);

            Console.WriteLine($"✅ Use Case: Feed sparades med ID: {input.Title}");

            return feed.Id;

        }

    }
}
