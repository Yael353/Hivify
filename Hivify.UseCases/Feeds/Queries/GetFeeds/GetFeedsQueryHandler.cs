using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;
using Hivify.UseCases.Feeds.DTOs;

namespace Hivify.UseCases.Feeds.Queries.GetFeeds;

public sealed class GetFeedsQueryHandler : IQueryHandler<GetFeedsQuery, IReadOnlyList<FeedListItemDto>>
{
    private readonly IFeedRepo _feedRepository;

    public GetFeedsQueryHandler(
        IFeedRepo feedRepository)
    {
        _feedRepository = feedRepository;
    }

    public async Task<IReadOnlyList<FeedListItemDto>> Handle(
        GetFeedsQuery query,
        CancellationToken cancellationToken)
    {
        var feeds =
            await _feedRepository.GetAllFeedsAsync(
                cancellationToken);

        return feeds
            .OrderByDescending(f => f.CreatedDate)
            .Select(f => new FeedListItemDto(
                f.Id.Value,
                f.Title.Value,
                f.Content.Value,
                f.CreatedDate))
            .ToList();
    }
}