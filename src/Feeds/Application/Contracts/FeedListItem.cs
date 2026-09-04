namespace Feeds.Application.Contracts;

public sealed record FeedListItem(
    Guid Id,
    string Title,
    string Content,
    DateTime CreatedDate);