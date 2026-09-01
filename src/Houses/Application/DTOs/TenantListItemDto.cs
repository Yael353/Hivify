namespace Houses.Application.DTOs;


public sealed record TenantListItemDto(
    Guid TenantId,
    Guid UserId,
    string Email,
    string FullName,
    string PhoneNumber,
    DateTime CreatedAt);