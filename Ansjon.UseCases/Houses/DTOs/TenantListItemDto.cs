namespace Ansjon.UseCases.Houses.DTOs;


public sealed record TenantListItemDto(
    Guid TenantId,
    Guid UserId,
    string Email,
    DateTime CreatedAt);