using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Feeds.Commands.UpdateFeed;

public sealed record UpdateFeedCommand(Guid FeedId, string Title, string Content) : ICommand<bool>;