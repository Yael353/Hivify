namespace Feeds.Application.DTOs;

public sealed record FeedListItemDto(
    Guid Id,
    string Title,
    string Content,
    DateTime CreatedDate);