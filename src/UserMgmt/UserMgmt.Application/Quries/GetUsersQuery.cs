using SharedKernel.Messaging;
using UserMgmt.Application.Contracts;

namespace UserMgmt.Application.Quries;

public sealed record GetUsersQuery : IQuery<IReadOnlyList<UserListItem>>;