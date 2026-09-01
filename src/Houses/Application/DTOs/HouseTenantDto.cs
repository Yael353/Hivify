namespace Houses.Application.DTOs;

public sealed record HouseTenantDto(
    Guid Id,
    string FirstName,
    string LastName,
    string FullName,
    string Email,
    string PhoneNumber,
    DateTime CreatedAt
);