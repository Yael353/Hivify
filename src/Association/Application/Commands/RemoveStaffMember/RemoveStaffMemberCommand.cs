using SharedKernel.Messaging;

namespace Hivify.Association.Application.Commands.RemoveStaffMember;

public sealed record RemoveStaffMemberCommand(
    Guid AssociationId,
    Guid MemberId) : ICommand<bool>;


