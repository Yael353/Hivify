using Ansjon.Core.Aggregates.Feeds;
using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Feeds.Commands.UpdateFeed;

public sealed record UpdateFeedCommand(
    FeedID FeedId,
    string Title,
    string Content)
    : ICommand<FeedID>;