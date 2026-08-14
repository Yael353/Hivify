using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.AdminUserMgmt.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Identity;

public sealed class UserManagementService
    : IUserManagementService
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
        var users = await _userManager.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return users
            .Select(MapToUserListItem)
            .ToList();
    }

    public async Task<UserListItem?> GetUserByIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        var user = await _userManager.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(
                user => user.Id == userId,
                cancellationToken);

        return user is null
            ? null
            : MapToUserListItem(user);
    }

    private static UserListItem MapToUserListItem(
        ApplicationUser user)
    {
        return new UserListItem(
            user.Id,
            user.UserName,
            user.Email,
            user.PhoneNumber,
            user.EmailConfirmed);
    }
}