using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Association.Commands.RemoveStaffMember;

public sealed record RemoveStaffMemberCommand(
    Guid AssociationId,
    Guid MemberId) : ICommand<bool>;