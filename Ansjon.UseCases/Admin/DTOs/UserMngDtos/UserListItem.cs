namespace Ansjon.UseCases.Admin.DTOs.UserMngDtos
{
    public sealed record UserListItem(
       Guid UserId,
       string? UserName,
       string? Email,
       bool EmailConfirmed);
}
