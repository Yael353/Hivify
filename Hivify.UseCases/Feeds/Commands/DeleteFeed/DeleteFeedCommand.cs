using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Feeds.Commands.DeleteFeed;

public sealed record DeleteFeedCommand(Guid FeedId) : ICommand<bool>;