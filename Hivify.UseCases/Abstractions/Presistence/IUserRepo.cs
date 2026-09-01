using Hivify.UseCases.AdminUserMgmt.DTOs;

namespace Hivify.UseCases.Abstractions.Presistence
{
    public interface IUserRepo
    {
        Task<IReadOnlyList<UserListItem>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<UserListItem?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
