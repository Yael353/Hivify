using Ansjon.UseCases.Admin.DTOs;
using Ansjon.UseCases.Admin.UserManagment;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Identity
{
    public sealed class UserManagementService : IUserManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagementService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IReadOnlyList<UserListItem>> GetUsersAsync(
            CancellationToken cancellationToken = default)
        {
            return await _userManager.Users
                .AsNoTracking()
                .Select(x => new UserListItem(
                    x.Id,
                    x.UserName,
                    x.Email,
                    x.EmailConfirmed))
                .ToListAsync(cancellationToken);
        }


    }
}
