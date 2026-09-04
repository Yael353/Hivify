namespace BuildingBlocks.ApplicationPorts.CurrentUserProvider
{
    public interface ICurrentUser
    {
        Task<Guid> GetUserIdAsync();

        Task<bool> IsInRoleAsync(string role);
    }
}
