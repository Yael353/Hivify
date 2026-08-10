namespace Ansjon.UseCases.Admin.DTOs
{
    public sealed record UserListItem(
       Guid UserId,
       string? UserName,
       string? Email,
       bool EmailConfirmed);
}
