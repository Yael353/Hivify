namespace Houses.Application.Contracts;


public sealed record TenantListItem(
    Guid TenantId,
    Guid UserId,
    string Email,
    string FullName,
    string PhoneNumber,
    DateTime CreatedAt);