using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.AdminUserMgmt.DTOs;

namespace Ansjon.UseCases.AdminUserMgmt.Queries.GetUsers;

public sealed record GetUsersQuery
    : IQuery<IReadOnlyList<UserListItem>>;