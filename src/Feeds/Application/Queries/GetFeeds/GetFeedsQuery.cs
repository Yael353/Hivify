using BuildingBlocks.ApplicationPorts.Messeging;
using Feeds.Application.Contracts;

namespace Feeds.Application.Queries.GetFeeds;

public sealed record GetFeedsQuery : IQuery<IReadOnlyList<FeedListItem>>;