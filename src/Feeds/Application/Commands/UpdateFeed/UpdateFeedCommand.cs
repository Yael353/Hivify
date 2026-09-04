using BuildingBlocks.ApplicationPorts.Messeging;

namespace Feeds.Application.Commands.UpdateFeed;

public sealed record UpdateFeedCommand(Guid FeedId, string Title, string Content) : ICommand<bool>;