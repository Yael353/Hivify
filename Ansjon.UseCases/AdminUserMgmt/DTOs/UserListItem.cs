namespace Ansjon.UseCases.AdminUserMgmt.DTOs;

public sealed record UserListItem(
    Guid Id,
    string? UserName,
    string? Email,
    string? PhoneNumber,
    bool EmailConfirmed);
