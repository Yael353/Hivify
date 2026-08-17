using Ansjon.Infrastructures.SqlDatabase;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.AdminUserMgmt.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Ansjon.Infrastructures.Repositories.UsersRepo;

public sealed class UsersRepo : IUserRepo
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public UsersRepo(
        IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<IReadOnlyList<UserListItem>> GetUsersAsync(
        CancellationToken cancellationToken = default)
    {
        await using var context =
            await _contextFactory.CreateDbContextAsync(
                cancellationToken);

        return await context.Users
            .AsNoTracking()
            .Select(user => new UserListItem(
                user.Id,
                user.UserName,
                user.Email,
                user.PhoneNumber,
                user.EmailConfirmed))
            .ToListAsync(cancellationToken);
    }

    public async Task<UserListItem?> GetUserByIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        await using var context =
            await _contextFactory.CreateDbContextAsync(
                cancellationToken);

        return await context.Users
            .AsNoTracking()
            .Where(user => user.Id == userId)
            .Select(user => new UserListItem(
                user.Id,
                user.UserName,
                user.Email,
                user.PhoneNumber,
                user.EmailConfirmed))
            .FirstOrDefaultAsync(cancellationToken);
    }
}