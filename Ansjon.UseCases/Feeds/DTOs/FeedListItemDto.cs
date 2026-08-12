namespace Ansjon.UseCases.Feeds.DTOs;

public sealed record FeedListItemDto(
    Guid Id,
    string Title,
    string Content,
    DateTime CreatedDate);