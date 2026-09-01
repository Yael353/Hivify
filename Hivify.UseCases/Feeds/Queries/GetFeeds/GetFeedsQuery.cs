using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Feeds.DTOs;

namespace Hivify.UseCases.Feeds.Queries.GetFeeds;

public sealed record GetFeedsQuery : IQuery<IReadOnlyList<FeedListItemDto>>;