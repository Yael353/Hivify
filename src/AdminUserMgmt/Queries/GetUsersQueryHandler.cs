using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;
using Hivify.UseCases.AdminUserMgmt.DTOs;

namespace Hivify.UseCases.AdminUserMgmt.Queries;

public sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, IReadOnlyList<UserListItem>>
{
    private readonly IUserRepo _userManagementService;

    public GetUsersQueryHandler(
        IUserRepo userManagementService)
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