using Feeds.Application.Contracts;
using SharedKernel.Messaging;

namespace Feeds.Application.Queries.GetFeeds;

public sealed record GetFeedsQuery : IQuery<IReadOnlyList<FeedListItem>>;