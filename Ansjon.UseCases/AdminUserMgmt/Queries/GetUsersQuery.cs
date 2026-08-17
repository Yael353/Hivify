using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.AdminUserMgmt.DTOs;

namespace Ansjon.UseCases.AdminUserMgmt.Queries;

public sealed record GetUsersQuery : IQuery<IReadOnlyList<UserListItem>>;