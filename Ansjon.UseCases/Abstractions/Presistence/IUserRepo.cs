using Ansjon.UseCases.AdminUserMgmt.DTOs;

namespace Ansjon.UseCases.Abstractions.Presistence
{
    public interface IUserRepo
    {
        Task<IReadOnlyList<UserListItem>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task<UserListItem?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
