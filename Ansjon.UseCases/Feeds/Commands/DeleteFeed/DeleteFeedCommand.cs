using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Feeds.Commands.DeleteFeed;

public sealed record DeleteFeedCommand(Guid FeedId) : ICommand<bool>;