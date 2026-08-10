using Ansjon.UseCases.Admin.DTOs;

namespace Ansjon.UseCases.Admin.UserManagment
{
    public interface IUserManagementService
    {
        Task<IReadOnlyList<UserListItem>> GetUsersAsync(CancellationToken cancellationToken = default);
    }
}
