using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Association.Commands.RemoveStaffMember;

public sealed record RemoveStaffMemberCommand(
    Guid AssociationId,
    Guid MemberId) : ICommand<bool>;