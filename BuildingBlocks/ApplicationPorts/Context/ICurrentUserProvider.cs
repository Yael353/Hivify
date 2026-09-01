namespace BuildingBlocks.ApplicationPorts.Context
{
    public interface ICurrentUser
    {
        Task<Guid> GetUserIdAsync();

        Task<bool> IsInRoleAsync(string role);
    }
}
