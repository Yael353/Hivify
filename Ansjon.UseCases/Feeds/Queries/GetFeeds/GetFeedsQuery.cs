using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Feeds.DTOs;

namespace Ansjon.UseCases.Feeds.Queries.GetFeeds;

public sealed record GetFeedsQuery : IQuery<IReadOnlyList<FeedListItemDto>>;