using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Feeds.DTOs;

namespace Ansjon.UseCases.Feeds.Queries.GetFeeds;

public sealed class GetFeedsQueryHandler
    : IQueryHandler<GetFeedsQuery, IReadOnlyList<FeedListItemDto>>
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