using Hivify.Core.Aggregates.Associations.Members;
using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Association.Commands.UpdateStaffMemberRole;

public sealed record UpdateStaffMemberRoleCommand(
    Guid AssociationId,
    Guid MemberId,
    MemberRole Role) : ICommand<bool>;