using Association.Domain.Members;
using BuildingBlocks.ApplicationPorts.Messeging;

public sealed record AddStaffMemberCommand(
    Guid AssociationId,
    Guid UserId,
    string FullName,
    string Email,
    MemberRole Role) : ICommand<MemberID>;


