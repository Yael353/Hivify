using BuildingBlocks.ApplicationPorts.Messeging;

namespace Feeds.Application.Commands.DeleteFeed;

public sealed record DeleteFeedCommand(Guid FeedId) : ICommand<bool>;