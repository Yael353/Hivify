using Association.Domain.Members;
using Hivify.UseCases.Abstractions.Messaging;

namespace Association.Application.Commands.UpdateStaffMemberRole;

public sealed record UpdateStaffMemberRoleCommand(
    Guid AssociationId,
    Guid MemberId,
    MemberRole Role) : ICommand<bool>;