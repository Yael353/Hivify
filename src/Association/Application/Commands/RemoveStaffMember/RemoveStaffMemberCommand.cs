using BuildingBlocks.ApplicationPorts.Messeging;

namespace Association.Application.Commands.RemoveStaffMember;

public sealed record RemoveStaffMemberCommand(
    Guid AssociationId,
    Guid MemberId) : ICommand<bool>;


