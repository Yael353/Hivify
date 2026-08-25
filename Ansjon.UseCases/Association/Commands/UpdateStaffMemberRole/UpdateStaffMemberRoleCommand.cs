using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Association.Commands.UpdateStaffMemberRole;

public sealed record UpdateStaffMemberRoleCommand(
    Guid AssociationId,
    Guid MemberId,
    MemberRole Role) : ICommand<bool>;