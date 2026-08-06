namespace Ansjon.UseCases.Houses.DTOs;

public sealed record HouseMemberDto(
    Guid Id,
    string FirstName,
    string LastName,
    string FullName,
    string Email,
    string PhoneNumber,
    DateTime CreatedAt
);