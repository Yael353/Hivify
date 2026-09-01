using Feeds.Application.DTOs;
using SharedKernel.Messaging;

namespace Feeds.Application.Queries.GetFeeds;

public sealed record GetFeedsQuery : IQuery<IReadOnlyList<FeedListItemDto>>;