namespace Ansjon.UseCases.Communications.InterFaces
{
    public interface ICurrentUser
    {
        Task<Guid> GetUserIdAsync();

        Task<bool> IsInRoleAsync(string role);
    }
}
