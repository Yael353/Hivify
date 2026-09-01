using Hivify.Association.Domain.Members;
using SharedKernel.Messaging;

namespace Hivify.Association.Application.Commands.UpdateStaffMemberRole;

public sealed record UpdateStaffMemberRoleCommand(
    Guid AssociationId,
    Guid MemberId,
    MemberRole Role) : ICommand<bool>;


