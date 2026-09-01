using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.AdminUserMgmt.DTOs;

namespace Hivify.UseCases.AdminUserMgmt.Queries;

public sealed record GetUsersQuery : IQuery<IReadOnlyList<UserListItem>>;