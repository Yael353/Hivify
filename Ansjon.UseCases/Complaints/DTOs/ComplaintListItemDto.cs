using Ansjon.Core.Aggregates.Complaints;

namespace Ansjon.UseCases.Complaints.DTOs;

public sealed record ComplaintListItemDto(
    Guid Id,
    string Title,
    string Description,
    ComplaintCategory Category,
    ComplaintStatus Status,
    DateTime CreatedDate,
    string? ImageUrl
);