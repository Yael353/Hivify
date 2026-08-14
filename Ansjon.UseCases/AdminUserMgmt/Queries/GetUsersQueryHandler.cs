using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.AdminUserMgmt.DTOs;

namespace Ansjon.UseCases.AdminUserMgmt.Queries.GetUsers;

public sealed class GetUsersQueryHandler
    : IQueryHandler<
        GetUsersQuery,
        IReadOnlyList<UserListItem>>
{
    private readonly IUserManagementService _userManagementService;

    public GetUsersQueryHandler(
        IUserManagementService userManagementService)
    {
        _userManagementService = userManagementService;
    }

    public async Task<IReadOnlyList<UserListItem>> Handle(
        GetUsersQuery query,
        CancellationToken cancellationToken)
    {
        return await _userManagementService.GetUsersAsync(
            cancellationToken);
    }
}