namespace Ansjon.UseCases.Admin.DTOs
{
    public sealed record UserDetails(
     Guid UserId,
     string? UserName,
     string? Email,
     bool EmailConfirmed,
     bool LockedOut);
}
