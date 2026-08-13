namespace Ansjon.UseCases.Houses.DTOs;

public sealed record TenantListItemDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    DateTime CreatedAt)
{
    public string FullName => $"{FirstName} {LastName}";
}