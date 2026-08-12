using Ansjon.UseCases.Admin.DTOs.UserMngDtos;

namespace Ansjon.UseCases.Abstractions.Presistence
{
    public interface IUserManagementService
    {
        Task<IReadOnlyList<UserListItem>> GetUsersAsync(CancellationToken cancellationToken = default);
    }
}
