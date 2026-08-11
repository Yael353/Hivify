using Ansjon.UseCases.Admin.DTOs;
using Ansjon.UseCases.Admin.UserManagment;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Identity
{
    public sealed class UserManagementService : IUserManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagementService(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IReadOnlyList<UserListItem>> GetUsersAsync(
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine("UserManagementService: entered");

            var users = await _userManager.Users
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            Console.WriteLine(
                $"UserManagementService: found {users.Count} users");

            return users
                .Select(user => new UserListItem(
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.EmailConfirmed))
                .ToList();
        }

    }
}
