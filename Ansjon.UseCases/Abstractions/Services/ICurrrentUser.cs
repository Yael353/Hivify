namespace Ansjon.UseCases.Abstractions.Services
{
    public interface ICurrentUser
    {
        Task<Guid> GetUserIdAsync();

        Task<bool> IsInRoleAsync(string role);
    }
}
