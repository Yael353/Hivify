namespace Ansjon.UseCases.Feeds.Commands.UpdateFeed;

public sealed record UpdateFeedCommand(
    Guid FeedId,
    string Title,
    string Content);