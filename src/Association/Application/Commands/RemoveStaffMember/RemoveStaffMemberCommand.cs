using Hivify.UseCases.Abstractions.Messaging;

namespace Association.Application.Commands.RemoveStaffMember;

public sealed record RemoveStaffMemberCommand(
    Guid AssociationId,
    Guid MemberId) : ICommand<bool>;